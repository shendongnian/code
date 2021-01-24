    AutomationPropertyChangedEventHandler TargetTitleBarHandler = null;
    Condition titleBarCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TitleBar);
    TitleBarElement = RootElement.FindFirst(TreeScope.Descendants, titleBarCondition);
    Automation.AddAutomationPropertyChangedEventHandler(TitleBarElement, TreeScope.Element,
        TargetTitleBarHandler = new AutomationPropertyChangedEventHandler(OnTargetTitleBarChange),
        AutomationElement.NameProperty);
    public void OnTargetTitleBarChange(object source, AutomationPropertyChangedEventArgs e)
    {
        if (e.Property == AutomationElement.NameProperty) { }
    }
