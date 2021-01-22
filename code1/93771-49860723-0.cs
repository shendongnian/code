            foreach(TabPage page in tabctr.TabPages)
            {
                if (page.Name == "tabPage2")
                {
                    tabctr.TabPages.Remove(page);
                }
            }
