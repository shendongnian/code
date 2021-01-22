            menu.MenuItems.Clear();
            HistoryItem[] crumbs = policyTree.Crumbs.GetCrumbs(nodeType);
            for (int i = crumbs.Length - 1; i > -1; i--) //Run through items backwards.
            {
                HistoryItem crumb = crumbs[i];
                NodeType type = nodeType; //Local to capture type.
                MenuItem menuItem = new MenuItem(crumb.MenuText);
                menuItem.Click += (s, e) => NavigateToRecord(crumb.ItemGuid, type);
                menu.MenuItems.Add(menuItem);
            }
