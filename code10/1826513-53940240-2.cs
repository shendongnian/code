    var oApp = new Microsoft.Office.Interop.Outlook.Application();
    var mapiNamespace = oApp.GetNamespace("MAPI");
    var calendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
    foreach (Microsoft.Office.Interop.Outlook.MAPIFolder folder in calendarFolder.Folders)
    {
        Console.WriteLine($"{folder.Name}");
    }
