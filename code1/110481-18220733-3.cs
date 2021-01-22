    using System;
    
    namespace WebApplication1
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Timer1_Tick(object sender, EventArgs e)
            {
                this.Label2.Text = "Done in 5 sec!";
            }
    
            protected void Timer2_Tick(object sender, EventArgs e)
            {
                this.Label1.Text = "Done in 10 sec!";
            }
        }
    }
