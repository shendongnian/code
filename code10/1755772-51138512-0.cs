    TextBox textBox = new TextBox();
    textBox.Style = FindResource("TextBoxStyle") as Style;
    ContextMenu cm = new ContextMenu();
    cm.Style = FindResource("DefaultContextMenuStyle") as Style;
    cm.Items.Add(new MenuItem() { Header = "Cut", Command = ApplicationCommands.Cut });
    cm.Items.Add(new MenuItem() { Header = "Copy", Command = ApplicationCommands.Copy });
    cm.Items.Add(new MenuItem() { Header = "Paste", Command = ApplicationCommands.Paste });
    textBox.ContextMenu = cm;
