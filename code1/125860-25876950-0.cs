    public class FocusMonitor
    {
        public FocusMonitor()
        {
            AutomationFocusChangedEventHandler focusHandler = OnFocusChanged;
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }
    
        private void OnFocusChanged(object sender, AutomationFocusChangedEventArgs e)
        {
            AutomationElement focusedElement = sender as AutomationElement;
            if (focusedElement != null)
            {
                int processId = focusedElement.Current.ProcessId;
                using (Process process = Process.GetProcessById(processId))
                {
                    Debug.WriteLine(process.ProcessName);
                }
            }
        }
    }
