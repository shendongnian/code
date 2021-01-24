    protected override void OnHandleDestroyed(EventArgs e)
    {
        Console.WriteLine("I'm being destroyed!");
        string myNumber = txMyNumber.Text;
        base.OnHandleDestroyed(e);
    }
