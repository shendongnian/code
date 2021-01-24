    using System;
    using System.Windows.Automation;
	
    namespace WorkstationLocked
    {
        class Program
        {
            static void Main()
            {
                AutomationElement el = AutomationUI.FindElementFromAutomationID("LockedMessage");
                if (el !=null)
                {
                    Console.WriteLine(el.Current.Name);
                }
            }
        }
        class AutomationUI
        {
            public static AutomationElement FindElementFromAutomationID(string automationID)
            {
                string className = "AUTHUI.DLL: LogonUI Logon Window";
                PropertyCondition condition = new PropertyCondition(AutomationElement.ClassNameProperty, className);
                AutomationElement logonui = AutomationElement.RootElement.FindFirst(TreeScope.Children, condition);
                if (logonui != null)
                {
                    condition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationID);
                    return logonui.FindFirst(TreeScope.Descendants, condition);
                }
                else
                {
                    return null;
                }
            }
        }
    }
