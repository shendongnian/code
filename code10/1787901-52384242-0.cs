    // Command to edit the current Group
    contextMenu.Commands.Add(new UICommand("Edit this Group", async (contextMenuCmd) =>
    {
        Frame.Navigate(typeof(LocationGroupCreator), groupName);
    }));
    
    // Command to delete the current Group
    contextMenu.Commands.Add(new UICommand("Delete this Group", async (contextMenuCmd) =>
    {
        SQLiteUtils rfd = new SQLiteUtils();
        rfd.DeleteGroupAsync(groupName);
    }));
