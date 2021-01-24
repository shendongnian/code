     newSubItems.ForEach(x =>
            {
                var subItem = new SubItem();
                subItem.Name = x.Name;
                subItem.ItemId = item.Id;/* missing line*/
                db.SubItems.Add(subItem);
            });
