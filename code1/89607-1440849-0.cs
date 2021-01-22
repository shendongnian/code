    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace HB
    {
    public class ScrollingLabel : Control{
    private float _maxX;
    private bool _needsScrolling;
    private static readonly StringFormat _nonScrollStrFmt = new StringFormat(StringFormatFlags.NoWrap);
    private static readonly StringFormat _strFmt = new StringFormat(StringFormatFlags.NoWrap);
    private float _txtWidth;
    private static readonly System.Threading.Timer _updateTimer = new System.Threading.Timer(ScrollText, 0, 0, 0);
    private static readonly object _updateTimerLock = new object();
    private float _x;
    private static event EventHandler _updateTimerTick;
    private static event EventHandler UpdateTimerTick
    {
      add
      {
        lock (_updateTimerLock)
        {
          bool flag = _updateTimerTick == null;
          _updateTimerTick = (EventHandler)Delegate.Combine(_updateTimerTick, value);
          if (flag && (_updateTimerTick != null))
          {
            _updateTimer.Change(0, 1000);
          }
        }
      }
      remove
      {
        lock (_updateTimerLock)
        {
          bool flag = _updateTimerTick == null;
          _updateTimerTick = (EventHandler)Delegate.Remove(_updateTimerTick, value);
          if (flag && (_updateTimerTick == null))
          {
            _updateTimer.Change(0, 0);
          }
        }
      }
    }
    public ScrollingLabel()
    {
    }
    private bool NeedsScrolling
    {
      get
      {
        return _needsScrolling;
      }
      set
      {
        if (_needsScrolling != value)
        {
          UpdateTimerTick -= UpdateText;
          _needsScrolling = value;
          if (_needsScrolling)
          {
            UpdateTimerTick += UpdateText;
          }
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
        if (_nonScrollStrFmt.Alignment != value)
        {
          _nonScrollStrFmt.Alignment = value;
          Invalidate();
        }
      }
    }
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        UpdateTimerTick -= UpdateText;
        _nonScrollStrFmt.Dispose();
      }
      base.Dispose(disposing);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.Clear(BackColor);
      using (SolidBrush brush = new SolidBrush(ForeColor))
      {
        if (NeedsScrolling)
        {
          e.Graphics.DrawString(Text, Font, brush, _x, 0f, _strFmt);
          e.Graphics.DrawString(Text, Font, brush, _x + _txtWidth, 0f, _strFmt);
          _x -= 5f;
          if (_x <= _maxX)
          {
            _x = 0f;
          }
        }
        else
        {
          e.Graphics.DrawString(Text, Font, brush, ClientRectangle, _nonScrollStrFmt);
        }
      }
      base.OnPaint(e);
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
    private static void ScrollText(object state)
    {
      EventHandler handler = _updateTimerTick;
      if (handler != null)
      {
        handler(null, EventArgs.Empty);
      }
    }
    private void UpdateNeedsScrollingFlag()
    {
      using (Graphics graphics = CreateGraphics())
      {
        float width = graphics.MeasureString(Text, Font).Width;
        if (width > Width)
        {
          NeedsScrolling = true;
          _txtWidth = width + 40f;
          _maxX = _txtWidth * -1f;
        }
        else
        {
          NeedsScrolling = false;
        }
      }
      _x = 0f;
    }
    private void UpdateText(object sender, EventArgs e)
    {
      if (!NeedsScrolling)
      {
        return;
      }
      try
      {
        BeginInvoke((MethodInvoker) delegate
        {
          if (!IsDisposed)
          {
            Invalidate();
          }
        });
      }
      catch
      {
        //BeginInvoke will exception if object already disposed.
      }
    }
