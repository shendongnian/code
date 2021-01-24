    public ActionResult Copy(Guid id)
        {
            Item item = db.Items.Find(id);
            Cat cat = db.Cats.Find(item.CatId);
            int newCopyValue = 0;
            string newName;
            List<Item> items = db.Items.Where(i => i.ItemName.Contains(item.ItemName)).OrderBy(i => i.ItemName.Length).ThenBy(i => i.ItemName).ToList();
            if (items.Count == 1)
            {
                newName = item.ItemName + " (1)";
            }
            else
            {
                Item lastCopy = items.ElementAt(items.Count - 1);
                String copyName = lastCopy.ItemName;
                if (copyName[copyName.Length - 3] == '(' && copyName[copyName.Length - 1] == ')')
                {
                    newCopyValue = Convert.ToInt32(copyName[copyName.Length - 2].ToString()) + 1;
                }
                else if (copyName[copyName.Length - 4] == '(' && copyName[copyName.Length - 1] == ')')
                {
                    string doubleDig = copyName[copyName.Length - 3].ToString() + copyName[copyName.Length - 2].ToString();
                    newCopyValue = Convert.ToInt32(doubleDig) + 1;
                }
                newName = item.ItemName + " (" +  newCopyValue.ToString() + ")";
            }
            Item copy = new Item(Guid.NewGuid(), newName, item.ItemDesc, item.ModelNo, item.RetailValue, item.ImageFileName, item.StartDate, item.EndDate, item.InitialBid, item.IncrementBy, null, null, null, cat);
            db.Items.Add(copy);
            db.SaveChanges();
            return RedirectToAction("Index", "Items", new {catId = item.CatId});
        }
