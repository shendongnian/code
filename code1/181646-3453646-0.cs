                FavsSection favconfig = (FavsSection)config.GetSection("FavouritesMenu");
                ToolStripMenuItem menu = (ToolStripMenuItem)returnMenuComponents("favouritesToolStripMenuItem", form);
                
                ToolStripItemCollection items = menu.DropDownItems;
                for (int i = 0; i < items.Count; i++)
                {
                    //favconfig.FavsItems[i].ID = i.ToString();
                    //favconfig.FavsItems[i].Path = items[i].Text;
                    favconfig.FavsItems[i] = new FavouriteElement()
                    {
                        ID = i.ToString(),
                        Path = items[i].Text
                    };
                }
