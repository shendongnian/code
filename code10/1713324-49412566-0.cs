        public void AnalyzeTree(List<TreeviewMenuItem> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                switch (menuItem)
                {
                    case MenuSubmenu submenu:
                        // TODO: submenu action
                        AnalyzeTree(submenu.Items);
                        break;
                    case MenuItem item:
                        // TODO: item action
                        break;
                }
            }
        }
