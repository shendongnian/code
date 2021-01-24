    var paint = System.Diagnostics.Process.GetProcessesByName("mspaint")
                        .FirstOrDefault();
    if (paint != null)
    {
        var paintMainWindow = paint.MainWindowHandle;
        var root = AutomationElement.FromHandle(paintMainWindow);
        var fillButton = root.FindAll(TreeScope.Subtree, Condition.TrueCondition)
            .Cast<AutomationElement>()
            .Where(x => x.Current.Name == "Fill with color").FirstOrDefault();
        if (fillButton != null)
        {
            var invokePattern = fillButton.GetCurrentPattern(InvokePattern.Pattern);
            if (invokePattern != null)
                ((InvokePattern)invokePattern).Invoke();
        }
    }
