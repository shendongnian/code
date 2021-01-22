        using System.Collections.Generic;
            using System.Linq;
            using System.Web;
            using System.Web.UI;
            using System.Web.Script.Serialization;
            using System.Web.Script.Services;
            using System.Web.Services;
            using System.Web.UI.WebControls;
            
            namespace test
            {
            	[ScriptService]
            	public partial class testing: System.Web.UI.Page
            	{
            		protected string strCaseID;
            		protected string jsonCase;
            
            		protected void Page_Load(object sender, EventArgs e)
            		{
            			if (!IsPostBack)
            			{
            				strCaseID =Tools.GetQueryObject("id");
                            // get a complex object with dates, string, arrays etc.
            				jsonESHACase = new JavaScriptSerializer().Serialize(objCase.Get(strCaseID ))
            					.Replace("\"\\/Date(", "Date(").Replace(")\\/\"", ")");
            			}
            		}
                }
            }
