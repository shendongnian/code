    public function test(TextBox text)
    {
        if(text.Text != "")
        {
            items.Add(text.Name, text.Text);
        }
    }
