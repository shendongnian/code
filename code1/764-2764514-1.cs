    protected override void OnPreviewKeyUp(System.Windows.Input.KeyEventArgs e)
    {
        base.OnPreviewKeyUp(e);
        if (BindingOperations.IsDataBound(this, TextBox.TextProperty))
        {
            if (this.Text.Length == 0)
            {
                this.SetValue(TextBox.TextProperty, "0");
                this.SelectAll();
            }
        }
    }
