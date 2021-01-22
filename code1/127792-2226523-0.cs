    for (int i = 0; i < 7; i++)
    {
        var copy = i;
    
        Button newButton = new Button();
    
        newButton.Text = "Click me!";
    
        newButton.Click += delegate(Object sender, EventArgs e)
        {
            MessageBox.Show("I am button number " + copy);
        };
    
        this.Controls.Add(newButton);
    }
