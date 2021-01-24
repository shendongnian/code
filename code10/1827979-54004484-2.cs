    using System.Windows.Automation;
    AutomationEventHandler NotepadHandlerOpen = null;
    AutomationEventHandler NotepadHandlerClose = null;
    AutomationPropertyChangedEventHandler NotepadTitleBarHandler = null;
    AutomationElement NotepadElement = AutomationElement.RootElement;
    AutomationElement TitleBarElement = null;
    using (Process NotepadProc = Process.GetProcessesByName("notepad").FirstOrDefault())
    {
        try
        {
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, NotepadElement,
                TreeScope.Subtree, NotepadHandlerOpen = new AutomationEventHandler(OnNotepadStart));
        }
        finally
        {
            if (NotepadProc != null)
                this.BeginInvoke(NotepadHandlerOpen, 
                    AutomationElement.FromHandle(NotepadProc.MainWindowHandle), 
                    new AutomationEventArgs(WindowPattern.WindowOpenedEvent));
        }
    }
    public void OnNotepadStart(object source, AutomationEventArgs e)
    {
        AutomationElement element = source as AutomationElement;
        if (e.EventId == WindowPattern.WindowOpenedEvent && element.Current.ClassName.Contains("Notepad"))
        {
            NotepadElement = element;
            Console.WriteLine("Notepad is now opened");
            Condition titleBarCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TitleBar);
            TitleBarElement = NotepadElement.FindFirst(TreeScope.Descendants, titleBarCondition);
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, NotepadElement,
                TreeScope.Element, NotepadHandlerClose = new AutomationEventHandler(OnNotepadClose));
            Automation.AddAutomationPropertyChangedEventHandler(TitleBarElement, TreeScope.Element,
                NotepadTitleBarHandler = new AutomationPropertyChangedEventHandler(OnNotepadTitleBarChange),
                AutomationElement.NameProperty);
        }
    }
    public void OnNotepadClose(object source, AutomationEventArgs e)
    {
        if (e.EventId == WindowPattern.WindowClosedEvent)
        {
            Console.WriteLine("Notepad is now closed");
            Automation.RemoveAutomationEventHandler(WindowPattern.WindowClosedEvent, NotepadElement, NotepadHandlerClose);
            Automation.RemoveAutomationPropertyChangedEventHandler(TitleBarElement, NotepadTitleBarHandler);
        }
    }
    public void OnNotepadTitleBarChange(object source, AutomationPropertyChangedEventArgs e)
    {
        if (e.Property == AutomationElement.NameProperty)
        {
            Console.WriteLine($"New TitleBar value: {e.NewValue}");
        }
    }
