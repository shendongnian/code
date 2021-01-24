    public string GetBrowsedUrl(Process process)
    {
        if (process.ProcessName == "firefox")
        {
            if (process == null)
                throw new ArgumentNullException("process");
    
            if (process.MainWindowHandle == IntPtr.Zero)
                return null;
    
            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;
    
            AutomationElement doc = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
            if (doc == null)
                return null;
    
            return ((ValuePattern)doc.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        }
        else
        {
            if (process == null)
                throw new ArgumentNullException("process");
    
            if (process.MainWindowHandle == IntPtr.Zero)
                return null;
    
            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;
    
            AutomationElement edit = element.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
    
    
            string result = ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            return result;
        }
       
    }
