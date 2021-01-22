    void Create(string text)
    { 
        TextBox t = new TextBox();
        t.ID = text;
        t.Text = text;
        pnl.Controls.Add(t);
    }
