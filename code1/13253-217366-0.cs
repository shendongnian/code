    public event EventHandler SaveButtonClick
    {
        add { this.SaveButton.Click += value; }
        remove { this.SaveButton.Click -= value; }
    }
