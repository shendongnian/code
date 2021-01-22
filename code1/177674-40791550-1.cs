    private void func_trd(String sender)
    {
    
        try
        {
            imgh.LoadImages_R_Randomiz(this, "01", groupBox, randomizerB.Value); // normal code
    
            ThreadStart ts = delegate
            {
                ExecuteInForeground(sender);
            };
            Thread nt = new Thread(ts);
            nt.IsBackground = true;
            nt.Start();
    
        }
        catch (Exception)
        {
            
        }
    }
    
    private void ExecuteInForeground(string name)
    {
         //whatever ur function
        MessageBox.Show(name);
    }
