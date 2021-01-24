    var notepad = System.Diagnostics.Process.GetProcessesByName("notepad").FirstOrDefault();
    if (notepad != null)
    {
        var root = AutomationElement.FromHandle(notepad.MainWindowHandle);
        var element = root.FindAll(TreeScope.Subtree, Condition.TrueCondition)
                            .Cast<AutomationElement>()
                            .Where(x => x.Current.ClassName == "Edit" &&
                                        x.Current.AutomationId == "15").FirstOrDefault();
        if (element != null)
        {
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out object pattern))
            {
                ((ValuePattern)pattern).SetValue("Something!");
            }
            else
            {
                element.SetFocus();
                SendKeys.SendWait("^{HOME}");   // Move to start of control
                SendKeys.SendWait("^+{END}");   // Select everything
                SendKeys.SendWait("{DEL}");     // Delete selection
                SendKeys.SendWait("Something!");
            }
        }
    }
 
