    foreach (CommandBinding cb in CommandBindings)
    {
        if (cb.Command.Equals(ApplicationCommands.Save))
        {
            ExecutedRoutedEventHandler f = null;
            f = (sender, e) =>
            {
                if (IsModified)
                {
                    BindingExpression be = rtb.GetBindingExpression(TextBox.TextProperty);
                    be.UpdateSource();
    
                    // There is a "Feature/Bug" in .Net which cancels the route when adding PreviewExecuted
                    // So we remove the handler and call execute again
                    cb.PreviewExecuted -= f;
                    cb.Command.Execute(null);
                }
            };
            cb.PreviewExecuted += f;
        }
    }
