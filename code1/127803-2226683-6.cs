    for (int i = 0; i < 7; i++)
    {
        var message = string.Format("I am button number {0}.", i);
    
        Button newButton = new Button();
        newButton.Text = "Click me!";
        newButton.Click += delegate(Object sender, EventArgs e)
        {
            MessageBox.Show(message);
        };
        this.Controls.Add(newButton);
    }
