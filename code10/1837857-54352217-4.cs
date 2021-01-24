    private bool isExiting = false;
    public void Exit()
    {
        isExiting = true;
    }
     public void ReadWrite()
     {           
         do
         {     
             var received = Read();
             if (_form.lst_BarcodeScan.InvokeRequired)
             {
                 _form.lst_BarcodeScan.Invoke(new MethodInvoker(delegate { _form.lst_BarcodeScan.Items.Add(received + Environment.NewLine); }));
             }
         } while (!isExiting)
         CloseConnection();
     }
