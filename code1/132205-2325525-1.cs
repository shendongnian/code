    private void CreateTabPages(TabControl tabControl, IEnumerable<Type> types)
    {
        foreach(var type in types)
        {
            var control = Activator.CreateInstance(type);
            var tabPage = new TabPage();
            tabPage.Controls.Add(control);
            tabControl.TabPages.Add(tabPage);
        }
    }
