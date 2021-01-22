    using System;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button2.Focus();
            Label1.Text = "button1 clicked & button2 in focus";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Focus();
            Label1.Text = "button2 clicked & button1 in Focus";
        }
    }
