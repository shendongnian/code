    private void button1_Click(object sender, EventArgs e)
    {
    
        try
        {
            imgh.LoadImages_R_Randomiz(this, "01", groupBox, randomizerB.Value); // normal code
    
            ThreadStart ts = delegate
            {
                ExecuteInForeground(" name");
            };
            Thread nt = new Thread(ts);
            nt.IsBackground = true;
            nt.Start();
    
        }
        catch (Exception)
        {
            
        }
    }
    
        public void ExecuteInForeground(string name)
        {
            MessageBox.Show(name);
        }
