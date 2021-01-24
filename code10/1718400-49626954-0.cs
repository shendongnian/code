    protected override void OnMouseClick(MouseEventArgs e)
    {
        Console.WriteLine("Before handlers");
        base.OnMouseClick(e);
        Console.WriteLine("After handlers");
    }
    void TextBox_MouseClick(object sender, EventArgs e)
    {
        Console.WriteLine("Handler");
    }    
