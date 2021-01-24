    var processStartInfo = new ProcessStartInfo(@"winword.exe");
    var application = Application.Launch(processStartInfo);
    TestStack.White.Application app = Application.Attach("winword");
    TestStack.White.UIItems.WindowItems.Window window = app.GetWindow("Microsoft Word");
    TestStack.White.UIItems.ListBoxItems.ComboBox whiteCombox = window.Get<ComboBox>(SearchCriteria.ByAutomationId("MyComboBox"));
    var flaUiAutomationElment = new FlaUI.UIA2.UIA2FrameworkAutomationElement(new UIA2Automation(), whiteCombox.AutomationElement);
    var flaUiComboBox = new FlaUI.Core.AutomationElements.ComboBox(flaUiAutomationElment);
