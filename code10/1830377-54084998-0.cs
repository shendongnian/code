            private static void ribbonButton_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Application application = new Outlook.Application();
            Outlook.Inspector inspector = application.ActiveInspector();
            if (application.ActiveExplorer().Selection[1] is Outlook.MailItem explorerMailItem)
            {
                // Write code to handle message if sourced from explorer (i.e., Reading Pane)
            }
            else if (inspector.CurrentItem is Outlook.MailItem inspectorMailItem)
            {
                // Write code to hanlde message if sourced from inspector 
                // (i.e., openened (double-clicked) message
            }
        }
