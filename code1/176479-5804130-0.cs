    public class MyBasePage : System.Web.UI.Page
    {
        // This declaration "forces" the Master property to be of your preferred type.
        public new MyMasterPage Master
        {
            get
            {
                return ((MyMasterPage)(base.Master));
            }
        }
    }
