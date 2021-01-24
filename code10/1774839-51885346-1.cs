    foreach (TabPage tp in tabControlWafers.TabPages)
    {
        TabControl tabControlStructure = new TabControl()
        {
            Dock = DockStyle.Fill
        };
        int numstruct = structures.Count();
        for (int i = 0; i < numstruct; i++)
        {
            TabPage tabPagestruct = new TabPage()
            {
                Name = structures[i],
                Text = structures[i]
            };
            tabControlStructure.TabPages.Add(tabPagestruct);
        }
        tp.Controls.Add(tabControlStructure);
    }
