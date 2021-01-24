    using System.Windows.Automation;
    public class ElementWindows
    {
        public int ProcessId { get; set; }
        public IntPtr MainWindowHandle { get; set; }
        public string MainWindowTitle { get; set; }
        public List<ElementWindows> SubWindows { get; set; }
    }
    public static List<ElementWindows> UIAFindWindows(int ProcessId, AutomationElement Root)
    {
        if (Root == null) Root = AutomationElement.RootElement;
        List <ElementWindows> results = new List<ElementWindows>();
        var MatchingWindows = Root.FindAll(
            TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
        foreach (AutomationElement Window in MatchingWindows)
        {
            object ElementProcessId = Window.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty, true);
            if (ElementProcessId != AutomationElement.NotSupported && ProcessId == (int)ElementProcessId)
            {
                ElementWindows foundElement = new ElementWindows()
                {
                    ProcessId = ProcessId,
                    MainWindowHandle = (IntPtr)Window.Current.NativeWindowHandle,
                    MainWindowTitle = Window.Current.Name,
                    SubWindows = UIAFindWindows(ProcessId, Window)
                };
                results.Add(foundElement);
            }
        }
        return results;
    }
