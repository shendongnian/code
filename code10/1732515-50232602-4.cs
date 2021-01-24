    public ICommand SetAmountCommand
    {
        get
        {
            return _setAmountCommand ?? (_setAmountCommand = new CommandParameterHandler((o) =>
            {
                CompositeParameter param = o as CompositeParameter;
                if (param != null)
                {
                    double amount = Convert.ToDouble(param.Value);
                    //...
                    TextBox textBox = param.Control as TextBox;
                    if (textBox != null)
                        textBox.Text = param.Value;
                }
            }, true));
        }
    }
