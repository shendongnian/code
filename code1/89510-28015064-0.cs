    public class AutoCompleteTextBox : TextBox
        {
            private ListBox _listBox;
            private bool _isAdded;
            private String[] _values;
            private String _formerValue = String.Empty;
    
            public AutoCompleteTextBox()
            {
                InitializeComponent();
                ResetListBox();
            }
    
            private void InitializeComponent()
            {
                _listBox = new ListBox();
                this.KeyDown += this_KeyDown;
                this.KeyUp += this_KeyUp;
            }
    
            private void ShowListBox()
            {
                if (!_isAdded)
                {
                    Form parentForm = this.FindForm(); // new line added
                    parentForm.Controls.Add(_listBox); // adds it to the form
                    Point positionOnForm = parentForm.PointToClient(this.Parent.PointToScreen(this.Location)); // absolute position in the form
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
                        {
                            if (_listBox.Visible)
                            {
                                Text = _listBox.SelectedItem.ToString();
                                ResetListBox();
                                _formerValue = Text;
                                this.Select(this.Text.Length, 0);
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
                if (Text == _formerValue)
                    return;
    
                _formerValue = this.Text;
                string word = this.Text;
    
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
                                _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : this.Width; ;
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
    
            public List<String> SelectedValues
            {
                get
                {
                    String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return new List<String>(result);
                }
            }
    
        }
