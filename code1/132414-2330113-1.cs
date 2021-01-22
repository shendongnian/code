    public string Header {
        get {
            string text = string.Empty;
            _HeaderComboBox.BeginInvoke(new MethodInvoker(delegate {
                text = _HeaderComboBox.Text;
            }));
            return text;
        }
        set {
            _HeaderComboBox.Text = value;
        }
    }
