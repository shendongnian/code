    UserContrl1_LOadDataMethod()
    {
        string name = "";
        if(textbox1.InvokeRequired)
        {
            textbox1.Invoke(new MethodInvoker(delegate { name = textbox1.text; }));
        }
        if(name == "MyName")
        {
            // do whatever
        }
    }
