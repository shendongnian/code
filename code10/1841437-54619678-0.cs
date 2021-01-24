AutomationElement desktop = AutomationElement.RootElement;
AutomationElment mainWindow = desktop.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "<Your Main Window Name>");
//... add code here to get from main window to where your screen shot starts
AutomationElement panello1 = mainWindow.FindAll(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "pannello"))[2];
AutomationElement tabulazione = panello1.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "tabulazione"));
AutomationElement panello2 = tabulazione.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "panello"));
AutomationElement interazioniPersonali = panello2.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Interazioni personali"));
AutomationElement elenco = interazioniPersonali.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "elenco"));
AutomationElement voceDiElenco = interazioniPersonali.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "voce di elenco"));
AutomationElement numero = voceDiElenco.FindAll(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "testo"))[2];
//... in if you expand the selected AutomationElement in your screenshot there should be a text element that contains the text you want to get
This can definitely be refined but this is just based on what I can see in the screen shot.
