    // in class scope
    private readonly Dictionary<string, ToolStripMenuItem> _menuItemsByName = new Dictionary<string, ToolStripMenuItem>();
    // in your method creating items
    ToolStripMenuItem createdItem = ...
    _menuItemsByName.Add("<name here>", createdItem);
    // to access it
    ToolStripMenuItem menuItem = _menuItemsByName["<name here>"];
