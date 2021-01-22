    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Management.Automation;
    using System.Text;
     
    namespace PowerShellExecution
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
     
            }
     
            protected void ExecuteCode_Click(object sender, EventArgs e)
            {
                // Clean the Result TextBox
                ResultBox.Text = string.Empty;
     
                // Initialize PowerShell engine
                var shell = PowerShell.Create();
     
                // Add the script to the PowerShell object
                shell.Commands.AddScript(Input.Text);
     
                // Execute the script
                var results = shell.Invoke();
     
                // display results, with BaseObject converted to string
                // Note : use |out-string for console-like output
                if (results.Count > 0)
                {
                    // We use a string builder ton create our result text
                    var builder = new StringBuilder();
     
                    foreach (var psObject in results)
                    {
                        // Convert the Base Object to a string and append it to the string builder.
                        // Add \r\n for line breaks
                        builder.Append(psObject.BaseObject.ToString() + "\r\n");
                    }
     
                    // Encode the string in HTML (prevent security issue with 'dangerous' caracters like < >
                    ResultBox.Text = Server.HtmlEncode(builder.ToString());
                }
            }
        }
    }
