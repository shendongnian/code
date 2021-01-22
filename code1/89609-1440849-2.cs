    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace MissingLink.Windows.Forms
    {
    public partial class ScrollingLabel : System.Windows.Forms.Control
    {
        private static readonly StringFormat _strFmt = new StringFormat(StringFormatFlags.NoWrap);
        private float _txtWidth;
        private bool _needsScrolling;
        private float _x;
        private float _maxX;
        private const int _whiteSpaceLength = 40;
        private const int _updateTime = 1000;
        private const int _updateX = 5;
        private static readonly System.Threading.Timer _updateTimer = new System.Threading.Timer(ScrollText, 0, 0, 0);
        private static readonly object _updateTimerLock = new object();
        private StringFormat _nonScrollStrFmt = new StringFormat(StringFormatFlags.NoWrap);
        private static event EventHandler _updateTimerTick;
        private static event EventHandler UpdateTimerTick
        {
            add
            {
                lock(_updateTimerLock)
                {
                    bool wasNull = (_updateTimerTick == null);
                    _updateTimerTick += value;
                    if(wasNull && (_updateTimerTick != null))
                    {
                        _updateTimer.Change(0, _updateTime);
                    }
                }
            }
            remove
            {
                lock(_updateTimerLock)
                {
                    bool wasNull = (_updateTimerTick == null);
                    _updateTimerTick -= value;
                    if(wasNull && (_updateTimerTick == null))
                    {
                        _updateTimer.Change(0, 0);
                    }
                }
            }
        }
        public ScrollingLabel()
        {
            InitializeComponent();
        }
        private bool NeedsScrolling
        {
            get
            {
                return _needsScrolling;
            }
            set
            {
                if(_needsScrolling == value)
                {
                    return;
                }
                UpdateTimerTick -= UpdateText;
                _needsScrolling = value;
                if(_needsScrolling)
                {
                    UpdateTimerTick += UpdateText;
                }
            }
        }
        public StringAlignment TextAlign
        {
            get
            {
                return _nonScrollStrFmt.Alignment;
            }
            set
            {
                if(_nonScrollStrFmt.Alignment == value)
                {
                    return;
                }
                _nonScrollStrFmt.Alignment = value;
                Invalidate();
            }
        }
        private void UpdateText(object sender, EventArgs e)
        {
            if(!NeedsScrolling)
            {
                return;
            }
            try
            {
                BeginInvoke((Action)(delegate
                {
                    if(IsDisposed)
                    {
                        return;
                    }
                    Invalidate();
                }));
            }
            catch { }
        }
        private static void ScrollText(object state)
        {
            EventHandler listeners = _updateTimerTick;
            if(listeners != null)
            {
                listeners(null, EventArgs.Empty);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            using(SolidBrush brush = new SolidBrush(ForeColor))
            {
                if(NeedsScrolling)
                {
                    e.Graphics.DrawString(Text, Font, brush, _x, 0, _strFmt);
                    e.Graphics.DrawString(Text, Font, brush, _x + _txtWidth, 0, _strFmt);
                    _x -= _updateX;
                    if(_x <= _maxX)
                    {
                        _x = 0;
                    }
                }
                else
                {
                    e.Graphics.DrawString(Text, Font, brush, ClientRectangle, _nonScrollStrFmt);
                }
            }
            base.OnPaint(e);
        }
        private void UpdateNeedsScrollingFlag()
        {
            using(Graphics graphics = CreateGraphics())
            {
                float txtWidth = graphics.MeasureString(Text, Font).Width;
                if(txtWidth > Width)
                {
                    NeedsScrolling = true;
                    _txtWidth = txtWidth + _whiteSpaceLength;
                    _maxX = _txtWidth * -1;
                }
                else
                {
                    NeedsScrolling = false;
                }
            }
            _x = 0;
        }
        protected override void OnResize(EventArgs e)
        {
            UpdateNeedsScrollingFlag();
            Invalidate();
            base.OnResize(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            UpdateNeedsScrollingFlag();
            Invalidate();
            base.OnTextChanged(e);
        }
    }
