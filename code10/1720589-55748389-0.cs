    [TestMethod]
    public void TestMethod2()
    {
        var app = FlaUI.Core.Application.Launch("WindowsFormsApp1.exe");
        app.WaitWhileBusy();
        using (var automation = new UIA3Automation())
        {
           var window = app.GetMainWindow(automation);
        
           var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("listBox1")).AsListBox();
           foreach (ListBoxItem item in listBox.Items)
           {
               Console.WriteLine(item.Patterns.LegacyIAccessible.Pattern.Description.Value);
           }
           window.Close();
        }
    }
