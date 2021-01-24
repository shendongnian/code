    namespace AWebForm
    {
        public class PassedData
        {
            public string material_type { get; set; }
            public string yardno { get; set; }
        }
        public partial class UnloadScreen : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            [WebMethod(EnableSession = true)]
            public static string SelectBRMfrmMaterialYardChk(PassedData formVars)
            {
                var r = JsonConvert.SerializeObject(formVars);
                return r;
            }
        }
    }
