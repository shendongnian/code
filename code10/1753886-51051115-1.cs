    // Occurs when all the clients have been bound to the Windows Forms BindingSource
    private void rosterBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
    {
        if (_dataDictionary != null)
        {
            _dataDictionary.Clear();
        }
        _dataDictionary = new Dictionary<string, Control>();
        rosterBindingSource_BindingData(this);
    }
    private void rosterBindingSource_BindingData(Control control)
    {
        foreach (var item in control.Controls)
        {
            var ctrl = item as Control;
            if (ctrl != null)
            {
                rosterBindingSource_BindingData(ctrl);
                // see what is data bound
                var bindable = item as IBindableComponent;
                if (bindable != null)
                {
                    foreach (Binding binding in bindable.DataBindings)
                    {
                        if (!_dataDictionary.ContainsKey(binding.PropertyName))
                        {
                            _dataDictionary.Add(binding.PropertyName, ctrl);
                        }
                    }
                }
            }
        }
    }
