        public void SaveOrder(IEnumerable<string> rows)
        {
            // Create a new order and add items
            var neworder = new Order_Master();
            foreach (var row in rows)
            {
                var valueslist = row.ToList();
                var oi = new Order_Item();
                oi.Item_Description = valueslist[0].ToString();
                // Set more properties...
                // Add the item to the order
                neworder.Order_Item.Add(oi);
            }
            // Instance a context, add the order and save
            try
            {
                using (var db = new OrderContext())
                {
                    db.Order_Master.Add(neworder);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to save to database: {e.Message}");
            }
        }
