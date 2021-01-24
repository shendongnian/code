    // Command to delete the current Group
    contextMenu.Commands.Add(new UICommand("Delete this Group", async (contextMenuCmd) =>
    {
        SQLiteUtils rfd = new SQLiteUtils();
        await rfd.DeleteGroupAsync(groupName);
    }));
