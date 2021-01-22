    AutoSizeButton button = new AutoSizeButton();
    button.Location = new Point(27, 52);
    button.Name = "button";
    button.Size = new Size(75, 23);
    button.Text = "Test";
    button.UseVisualStyleBackColor = true;
    button.Image = Image.FromFile(path);
    Controls.Add(button);
