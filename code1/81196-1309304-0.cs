    AutomationElement a, b;
    Process p;
    Process[] existingProcesses;
    IAccessible c;
    
    existingProcesses = Process.GetProcessesByName("OurApp");
    if (existingProcesses.Length > 0) {
      p = existingProcesses[0];
      a = AutomationElement.FromHandle(p.MainWindowHandle);
      b = a.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "LeftNavExplorerBarGroups"));
      c = MSAA.GetAccessibleObjectFromHandle(new IntPtr(b.Current.NativeWindowHandle));
    }
