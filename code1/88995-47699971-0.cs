                DataTable dt = GetCustomersDataTable(null);            
            
                IEnumerable<SelectListItem> lstCustomer = dt.AsEnumerable().Select(x => new SelectListItem()
                {
                    Value = x.Field<string>("CustomerId"),
                    Text = x.Field<string>("CustomerDescription")
                }).ToList();
                return lstCustomer;
         
