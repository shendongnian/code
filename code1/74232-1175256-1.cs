    protected override bool OnBubbleEvent(object source, EventArgs args)
    {
        if (args is CommandEventArgs)
        {
            CommandEventArgs cArgs = (CommandEventArgs)args;
            if (cArgs.CommandName == "SelectedIndexChanged")
            {
                Control c = GetPaymentControl((char?)cArgs.CommandArgument);
                // ...
                updatePanel.Update();
                return true;
            }
        }
        return base.OnBubbleEvent(source, args);
    }
