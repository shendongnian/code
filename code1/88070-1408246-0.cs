    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services
    
    namespace Second_Question
    {
        public partial class Delete : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            
            [WebMethod]
            public static void DeleteCustomer(int CustID)
            {
    
                var dataContext = new CustomersDataContext();
                var customer = from m in dataContext.Customers
                               where m.id == CustID
                               select m;
                dataContext.Customers.DeleteAllOnSubmit(customer);
                dataContext.SubmitChanges();
    
    
            }
        }
    }
