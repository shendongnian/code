    public Button Clone(Button input)
    {
        var output = new Button();
        output.Text = input.Text;
        // do the same for other properties that you need to clone
        output.Click += (s,e)=>input.PerformClick();
        return output;
    }
