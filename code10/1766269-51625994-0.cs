    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Automation;
    
    namespace UiaTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var p = Process.GetProcessesByName("notepad").FirstOrDefault();       
                var root = AutomationElement.FromHandle(p.MainWindowHandle);
        
                var documentControl = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
                var textPatternAvailable = new PropertyCondition(AutomationElement.IsTextPatternAvailableProperty, true);
                var findControl = new AndCondition(documentControl, textPatternAvailable);
        
                var targetDocument = root.FindFirst(TreeScope.Descendants, findControl);    
                var textPattern = targetDocument.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
    
                foreach (var selection in textPattern.GetSelection())
                {
                    Console.WriteLine($"Selection: \"{selection.GetText(255)}\"");
                }    
            }
        }
    }
