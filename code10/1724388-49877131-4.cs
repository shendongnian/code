    var model = new TVSystemViewData();
            PropertyInfo[] properties = typeof(TVSystemViewData).GetProperties();
            List<string> items = new List<string> { "AccountId", "AllocatedManagedMemory" }; //your collection of strings
            
            foreach (var item in items)
            {
                foreach (var property in properties)
                {
                    if (item == property.Name)
                    {
                        property.SetValue(model, shell.getParameter(item));
                    }
                }
            }
