    // Case A
    Container.Controls.AddAndReturn(new Button
    {
        Name = "Button Name",
        Text = "Button Text",
        Size = new Size(69, 69),
        Location = new Point(420, 420)
    }).Click += DesignerButton_OnClick;
    // Case B
    Container.Controls.Add(new Button
    {
        Name = "Button Name",
        Text = "Button Text",
        Size = new Size(69, 69),
        Location = new Point(420, 420)
    }, returnControl: true).Click += DesignerButton_OnClick;
