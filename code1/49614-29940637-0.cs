            <form id="form1" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Create New Directory" onclick="createButton_Click" />            
                <br /><br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </form>
       
     **CODEBEHIND**
=============================================================================        
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Configuration;
    using System.IO;
    
    namespace RakeshDadamatti
    {
        public partial class CreateDirectory : System.Web.UI.Page
        {
            String newDirectory;
            String subDirectory;
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            private void CreatenewDirectory(string newDirectory)
            {
                try
                {
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                        Label1.Text = "Directory Has Been Created.";
                    }
                    else
                    {
                        Label1.Text = "Directory Exists.";
                    }
    
                    if (!Directory.Exists(subDirectory))
                    {
                        Directory.CreateDirectory(subDirectory);
                        Label2.Text = "Sub Directory Has Been Created.";
                    }
                    else
                    {
                        Label2.Text = "Sub Directory Exists.";
                    }
                }
                catch (IOException _err)
                {
                    Response.Write(_err.Message);
                }
            }
            protected void createButton_Click(object sender, EventArgs e)
            {
                newDirectory = Server.MapPath("Directory Name Here");
                subDirectory = Server.MapPath(@"" + "~/" + newDirectory + "/" + "Sub Directory Name Here");
                CreatenewDirectory(newDirectory);
            }
        }
    }
