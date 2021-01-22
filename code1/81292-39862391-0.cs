     void UseCustomFont(string name, int size, Label label)
        {
    
            PrivateFontCollection modernFont = new PrivateFontCollection();
    
            modernFont.AddFontFile(name);
    
            label.Font = new Font(modernFont.Families[0], size);
    
    
        }
    
     
