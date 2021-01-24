        // The id parameter name should match the DataKeyNames value set on the control
        public void EmployeeTable_UpdateItem(int id)
        {
            InvMS.Models.Employee item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Create a connection to your database here, 
                // Map the attributes to your stored procedure and call the procedure
            }
        }
        // The id parameter name should match the DataKeyNames value set on the control
        public void EmployeeTable_DeleteItem(int id)
        {
        }
