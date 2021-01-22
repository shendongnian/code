    using System.Windows.Forms;
    namespace TestWebBrowser
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    
    			webBrowser1.DocumentText = @"<html><body><table>
        <tbody>
        <tr>
    
            <td><label class=""label"">Name</label></td>
            <td class=""normaltext"">John Smith</td>
        </tr>
        <tr>    <td><label class=""label"">Email</label></td>
            <td><span class=""normaltext"" id=""e1"">jsmith@hotmail.com</span></td>
    </tr>
        </tr>
        </tbody>
    </table>
    </body>
    </html>";
    		}
    
    		private void button1_Click(object sender, System.EventArgs e)
    		{
    			HtmlElement e1 = webBrowser1.Document.GetElementById("e1");
    			MessageBox.Show(e1.InnerText);
    		}
    	}
    }
