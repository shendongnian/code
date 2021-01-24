    public static void Main(string[] args)
    {
        Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Children, (sender, e) =>
        {
            var element = sender as AutomationElement;
            if (element.Current.Name == "Параметры быстродействия")
            {
                Console.WriteLine("hwnd:" + element.Current.NativeWindowHandle);
            }
        });
        Process.Start("SystemPropertiesPerformance.exe");
        Console.ReadLine(); // wait ...
        Automation.RemoveAllEventHandlers(); // cleanup
    }
