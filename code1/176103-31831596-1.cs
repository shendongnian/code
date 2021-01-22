    static void HandleValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        NumericUpDown nud = obj as NumericUpDown;
        if (nud == null)
            return;
    
        BindingExpression be = nud.GetBindingExpression(NumericUpDown.ValueProperty);
        if(be != null)
            be.UpdateSource();
    }
