      Language[] items = new Language[]{new Language("English", "En"),
                    new Language("Italian", "It")};
    
                languagesCombo.ValueMember = "Alias";
                languagesCombo.DisplayMember = "FullName";
                languagesCombo.DataSource = items.ToList();
    
                languagesCombo.DropDownStyle = ComboBoxStyle.DropDownList;
     class Language
        {
            public string FullName { get; set; }
            public string Alias { get; set; }
    
            public Language(string fullName, string alias)
            {
                this.FullName = fullName;
                this.Alias = alias;
            }
        }
