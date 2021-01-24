        olApplication = new Microsoft.Office.Interop.Outlook.Application();
        m = olApplication.CreateItem(OlItemType.olMailItem);
        Recipient r = m.Recipients.Add("joe.bloggs");
        r.Type = (int)OlMailRecipientType.olBCC;
        m.Display(true);
