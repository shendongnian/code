    using System.Net.Sockets;
    using System.Text;
    using System.IO;
    using System.Collections;
    using System.Net;
    using System.Text.RegularExpressions;
    
    
    public partial class WhoIsC : System.Web.UI.Page
    {
    
        #region " Web Form Designer Generated Code "
    
        //This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
    
        }
    
        protected void  // ERROR: Handles clauses are not supported in C#
    Page_Init(System.Object sender, System.EventArgs e)
        {
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
        }
    
        #endregion
    
        private void  // ERROR: Handles clauses are not supported in C#
    Page_Load(System.Object sender, System.EventArgs e)
        {
            // Adds the java script code for clearing  the existing text from the text box when user wants to
            // enter a new domain name
            txtDomain.Attributes.Add("onclick", "this.value='';");
        }
    
        public  void  // ERROR: Handles clauses are not supported in C#
    btnQuery_Click(System.Object sender, System.EventArgs e)
        {
            string firstLevelbufData = null;
            // Stores the bufData extracted from the webclient 
            try
            {
                // similarly we can select any server address for bufData mining
                string strURL = "http://www.directnic.com/whois/index.php?query=" + txtDomain.Text;
                WebClient web = new WebClient();
                // byte array to store the extracted bufData by webclient
                byte[] bufData = null;
                bufData = web.DownloadData(strURL);
                // got the bufData now convert it into string form
                firstLevelbufData = Encoding.Default.GetString(bufData);
            }
            catch (System.Net.WebException ex)
            {
                // this exception will be fired when the host name is not resolved or any other connection problem
                txtResult.Text = ex.Message.ToString();
                return;
            }
            try
            {
                // first and last are the regular expression string for extraction bufData witnin two tags
                // you can change according to your requirement
                string first = null;
                string last = null;
                // chr(34) is used for (") symbol
                first = "<p class=\"text12\">";
                last = "</p>";
    
                Regex RE = new Regex(first + "(?<MYDATA>.*?(?=" + last + "))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                // try to extract the bufData  within the first and last tag
                Match m = RE.Match(firstLevelbufData);
                // got the result
                txtResult.Text = m.Groups["MYDATA"].Value + "<br>";
                // check if no information abour that domain is available
                if (txtResult.Text.Length < 10) txtResult.Text = "Information about this domain is not available !!";
            }
            catch (System.Net.WebException ex)
            {
                txtResult.Text = "Sorry the whois information is currently not available !!";
            }
        }
    
    }
