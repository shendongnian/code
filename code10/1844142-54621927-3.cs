`C#
        private void Form1_Load(object sender, EventArgs e)
        {
            // Configure the context menu
            var menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Copy", (s, ev) =>
            {
                if ((s as MenuItem).Tag is Label clickedLabel)
                {
                    Clipboard.SetText(clickedLabel.Text);
                }
            })
            { Name = "Copy" });
            // Add the context menu and the MouseClick event to each label
            foreach (var label in Controls.OfType<Label>())
            {
                label.ContextMenu = menu;
                label.MouseClick += (clickedLabel, clickInfo) =>
                {
                    if (clickInfo.Button != MouseButtons.Right) return;
                    menu.MenuItems["Copy"].Tag = clickedLabel;
                };
            }
        }
`
**ORIGINAL ANSWER** (modified for handling right click; works if context menu is not used):
Subscribe the `MouseClick` event of the label to the same event handler:
`C#
    // in your load or shown event handler:
    label1.MouseClick += anyLabel_MouseClick;
    // ... rinse, repeat...
    label10.MouseClick += anyLabel_MouseClick;
`
If you want to add this functionality for _all labels_, you can loop through them:
`C#
    foreach(var label in Controls.OfType<Label>())
    {
        label.MouseClick += anyLabel_MouseClick;
    }
`
Then,  in the event handler:
`C#
    private void anyLabel_MouseClick(object sender, MouseEventArgs e)
    {
        if(e.Button != MouseButtons.Right) return;
        if(sender is Label label)
        {
            ClipBoard.SetText(label.Text);
        }
    }
`
