    public void GetList()
    {
        int var = 0;
    
        string[] files = Directory.GetFiles(path, "*");
    
        foreach (var fileExt in files)
        {
            string p = fileExt;
            string e = Path.GetExtension(p);
    
            string newVar = ".state" + var;
    
            if (e == ".state" || e == newVar)
            {
                MessageBox.Show(newVar);
            }
    
            var++;
    
            MessageBox.Show(newVar);
            MessageBox.Show(e);
        }
    }
