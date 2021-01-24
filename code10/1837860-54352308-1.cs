    public void ReadWrite()
    {           
        while (true)
        {
            var command = "";
            if (command == "Exit")
                break;
    
            var received = Read();
            if(received == null)
                break;
            if (_form.lst_BarcodeScan.InvokeRequired)
            {
            _form.lst_BarcodeScan.Invoke(new MethodInvoker(delegate { _form.lst_BarcodeScan.Items.Add(received + Environment.NewLine); }));
            }
        }
    
        CloseConnection();
    }
