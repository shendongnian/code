    var andCondition = new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), new PropertyCondition(AutomationElement.NameProperty, "Allow"));
                
    AutomationElement chromeWindow = AutomationElement.FromHandle(_windowPointer); // IntPtr type
    var buttonsFound = chromeWindow.FindAll(TreeScope.Descendants,  andCondition);
    if (buttonsFound.Count > 0)
    {
       var button = buttonsFound[0];
       var clickPattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
       clickPattern.Invoke();
    }
