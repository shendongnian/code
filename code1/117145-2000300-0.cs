    private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {
        Console.WriteLine("rejected char");
    }
    private void maskedTextBox1_TextChanged(object sender, EventArgs e)
    {
        Console.WriteLine("accepted char");
    }
