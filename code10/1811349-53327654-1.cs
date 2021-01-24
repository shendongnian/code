    public void button1_Click(object sender, EventArgs e)
    {
        i++;
        var button = new Button();
        this.Controls.Add(button);
        button.Click += new EventHandler(Click);
        buttonDictionary.Add(button, null);
    }
