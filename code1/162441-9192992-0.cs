    `using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    /*CREDENTIAL CLASS' NAMESPACE*/
    using System.Net;
    using OpenContactsNet;
    namespace WebApplication1
    {
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenContactsNet.GmailExtract gm = new OpenContactsNet.GmailExtract();
            NetworkCredential nw = new NetworkCredential("tresorunikin@gmail.com", "titinik");
            OpenContactsNet.MailContactList ml = new OpenContactsNet.MailContactList();
            gm.Extract(nw, out ml);
    //Triyng to Show somethin
            Response.Write(ml.Count+" Contacts : ");
            foreach(MailContact mc in ml){
                Response.Write(mc.Email+"<hr size='1'/>");
            }
        }
      }
    }` 
