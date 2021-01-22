    var boxes = form.Controls.OfType<TextBox>().ToDictionary(t => t.Name);
    public void Update(string name, int newValue)
    {
        boxes[name].Text = newValue.ToString();
    }
