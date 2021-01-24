    private bool _changing;
    private void ScrollingFromTextBoxToScrollBar()
    {
        if (!_changing) {
            _changing = true;
            try {
                vScrollBar1.Minimum = textBox1.VerticalScroll.Minimum;
                vScrollBar1.Maximum = textBox1.VerticalScroll.Maximum;
                vScrollBar1.Value = textBox1.VerticalScroll.Value;
            } finally {
                _changing = false;
            }
        }
    }
    private void ScrollingFromScrollBarToTextBox()
    {
        if (!_changing) {
            _changing = true;
            try {
                textBox1.VerticalScroll.Minimum = vScrollBar1.Minimum;
                textBox1.VerticalScroll.Maximum = vScrollBar1.Maximum;
                textBox1.VerticalScroll.Value = vScrollBar1.Value;
            } finally {
                _changing = false;
            }
        }
    }
