    int y = 10;
    foreach (string name in names)
    {        
        Button button = new Button();
        button.Text = name;
        button.Position = new Point(10, y);
        y += 20;
        button.Click += HandleButtonClick;
        Controls.Add(button);
    }
