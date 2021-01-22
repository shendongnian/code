    private void Form_Shown(object sender)
    {
        Thread t = new Thread(new ParameterizedThreadStart(Dummy));
        t.Start(this);
    }
    ....
    private static void Dummy(object state)
    {
        MyForm f = (MyForm)state;
    
        f.Invoke((MethodInvoker)delegate()
        {
            f.label1.Text = " New Text ";
        });
    }
