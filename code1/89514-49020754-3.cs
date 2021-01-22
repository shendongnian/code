    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class MultiLineAutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private String[] _values;
        private String _formerValue = String.Empty;
        private int _prevBreak;
        private int _nextBreak;
        private int _wordLen;
        public MultiLineAutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }
        private void InitializeComponent()
        {
            _listBox = new ListBox();
            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;
        }
        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Form parentForm = FindForm();
                if (parentForm == null) return;
                parentForm.Controls.Add(_listBox);
                Point positionOnForm = parentForm.PointToClient(Parent.PointToScreen(Location));
                _listBox.Left = positionOnForm.X;
                _listBox.Top = positionOnForm.Y + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }
        private void ResetListBox()
        {
            _listBox.Visible = false;
        }
        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }
        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                case Keys.Space:
                {
                    if (_listBox.Visible)
                    {
                        Text = Text.Remove(_prevBreak == 0 ? 0 : _prevBreak + 1, _prevBreak == 0 ? _wordLen + 1 : _wordLen);
                        Text = Text.Insert(_prevBreak == 0 ? 0 : _prevBreak + 1, _listBox.SelectedItem.ToString());
                        ResetListBox();
                        _formerValue = Text;
                        Select(Text.Length, 0);
                        e.Handled = true;
                    }
                    break;
                }
                case Keys.Down:
                {
                    if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                        _listBox.SelectedIndex++;
                    e.Handled = true;
                    break;
                }
                case Keys.Up:
                {
                    if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                        _listBox.SelectedIndex--;
                    e.Handled = true;
                    break;
                }
            }
        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (_listBox.Visible)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }
        private void UpdateListBox()
        {
            if (Text == _formerValue) return;
            if (Text.Length == 0)
            {
                _listBox.Visible = false;
                return;
            }
            _formerValue = Text;
            var separators = new[] { '|', '[', ']', '\r', '\n', ' ', '\t' };
            _prevBreak = Text.LastIndexOfAny(separators, CaretIndex > 0 ? CaretIndex - 1 : 0);
            if (_prevBreak < 1) _prevBreak = 0;
            _nextBreak = Text.IndexOfAny(separators, _prevBreak + 1);
            if (_nextBreak == -1) _nextBreak = CaretIndex;
            _wordLen = _nextBreak - _prevBreak - 1;
            if (_wordLen < 1) return;
            string word = Text.Substring(_prevBreak + 1, _wordLen);
            if (_values != null && word.Length > 0)
            {
                string[] matches = Array.FindAll(_values,
                    x => (x.ToLower().Contains(word.ToLower())));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.BeginUpdate();
                    _listBox.Items.Clear();
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    _listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            if (i < 20)
                                _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            int itemWidth = (int)graphics.MeasureString(((string)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : Width; ;
                        }
                    }
                    _listBox.EndUpdate();
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }
        public int CaretIndex => SelectionStart;
        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }
    }
