    public void GetList()
    {
        int var = 0;
        string newVar = ".state" + var;
    
        string[] files = Directory.GetFiles(path, "*");
    
        foreach (var fileExt in files)
        {
            string p = fileExt;
            string e = Path.GetExtension(p);
    
            if (e.StartsWith(".state"))
            {
                MessageBox.Show(newVar); //shows .state / no others
            }
    
            var++;
    
            MessageBox.Show(newVar); //shows newVar incrementing
            MessageBox.Show(e); //shows extension
        }
    }
