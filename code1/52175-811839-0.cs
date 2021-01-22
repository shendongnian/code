    public enum AutomotiveTypes
    {
        Car,
        Truck,
        Van,
        Train,
        Plane
    }
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] automotiveTypeNames = Enum.GetNames(typeof(AutomotiveTypes));
            RadioButtonList1.RepeatDirection = RepeatDirection.Vertical;
            RadioButtonList1.DataSource = automotiveTypeNames;
            RadioButtonList1.DataBind();
        }
    }
