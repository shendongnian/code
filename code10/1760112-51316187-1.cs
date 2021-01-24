    var NewButton = new Button
    {
        Parent = Container,
        Name = "Button Name",
        Text = "Button Text",
        Size = new Size(69, 69),
        Location = new Point(420, 420)
    };
    NewButton.Click += DesignerButton_OnClick;
