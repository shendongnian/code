    public static void Dummy(object state)
    {
        MyForm f = (MyForm)state;
    
        f.Invoke((MethodInvoker)delegate()
        {
            label1.Text = " New Text ";
        });
    }
