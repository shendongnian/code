    for (int i = 10; i < 70; i++)
    {
        Button rbtn = new Button();
        rbtn.Text = i.ToString();
        ribbonComboBox2.Items.Add(rbtn);
        ribbonComboBox2.DisplayMember = "Text";
    }
    
            
    System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
    foreach (FontFamily family in fonts.Families)
    {
        Button rbtn = new Button();
        rbtn.Text = family.Name.ToString();
        ribbonComboBox1.Items.Add(rbtn);
        ribbonComboBox1.DisplayMember = "Text";
    }
