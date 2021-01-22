       using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
    **using System.Windows.Forms;**
    
        public partial class _Default : System.Web.UI.Page 
       {
          protected void Page_Load(object sender, EventArgs e)
           {
              MessageBox.Show("Machine Cannot Be Deleted", "Delete from other Places                   
              first", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
           }    
        }
