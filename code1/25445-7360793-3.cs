    protected override void OnKeyPress(KeyPressEventArgs ex)
    {
        string xo = ex.KeyChar.ToString();
        if (xo == "q") //You pressed "q" key on the keyboard
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
