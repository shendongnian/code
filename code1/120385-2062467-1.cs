    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           int a =  Convert.ToInt32(TextBox1.Text);
           int b = Convert.ToInt32(TextBox2.Text);
           int sum = Add(a, b);
    
           // do something with it like return it to a lbl.
           Label1.Text = sum.ToString();
        }
    
        private int Add(int a, int b)
        {
            return a + b;
        }
    }
