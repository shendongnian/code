    new Button
    {
        Parent = Container, // the same as Container.Controls.Add
        Name = "Button Name",
        Text = "Button Text",
        Size = new Size(69, 69),
        Location = new Point(420, 420)
    }.Click += DesignerButton_OnClick;
