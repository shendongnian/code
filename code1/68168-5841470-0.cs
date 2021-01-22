    public static IEnumerable<SelectListItem> GetCustomerList()
    		{
    			using (SiteDataContext db = new SiteDataContext())
    			{
    				var list = from l in db.Customers.AsEnumerable()
    						   orderby l.CompanyName
    						   select new SelectListItem { Value = l.CustomerID.ToString(), Text = l.CompanyName };
    
    				return list.ToList();
    			}
    		}
