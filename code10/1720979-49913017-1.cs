    public class GridViewDropDownListTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            DropDownList ddlStatus = new DropDownList();
            ddlStatus.ID = "ddlStatus";
            ddlStatus.Items.Add(new ListItem("Status 1"));
            ddlStatus.Items.Add(new ListItem("Status 2"));
            ddlStatus.Items.Add(new ListItem("Status 3"));
            ddlStatus.Items.Add(new ListItem("Status 4"));
            ddlStatus.AutoPostBack = true;
            ddlStatus.SelectedIndexChanged += ddlStatus_SelectedIndexChanged;
            container.Controls.Add(ddlStatus);
        }
        public void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
    public class GridViewButtonTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            Button btnSave = new Button();
            btnSave.ID = "btnSave";
            btnSave.Text = "Save";
            container.Controls.Add(btnSave);
        }
    }
    public partial class Default : System.Web.UI.Page
    {
        object[] data = new[]
        {
            new { Amount = 12500.00, Account = "1234-567-89" },
            new { Amount = 87000.00, Account = "0000-999-88" }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuildBoundFields();
            }
            BuildTemplateFields();
            BindData();
        }
        protected void BuildBoundFields()
        {
            // Amount bound field
            BoundField boundFieldAmount = new BoundField();
            boundFieldAmount.DataField = "Amount";
            boundFieldAmount.HeaderText = "Amount";
            boundFieldAmount.SortExpression = "Amount";
            boundFieldAmount.ItemStyle.Width = Unit.Pixel(100);
            gvDetails.Columns.Add(boundFieldAmount);
            // Account bould field
            BoundField boundFieldAccount = new BoundField();
            boundFieldAccount.DataField = "Account";
            boundFieldAccount.HeaderText = "Account";
            boundFieldAccount.SortExpression = "Account";
            boundFieldAccount.ItemStyle.Width = Unit.Pixel(250);
            gvDetails.Columns.Add(boundFieldAccount);
            // ...
        }
        protected void BuildTemplateFields()
        { 
            // Status template field
            TemplateField statusTemplateField = new TemplateField();
            statusTemplateField.ItemTemplate = new GridViewDropDownListTemplate();
            gvDetails.Columns.Add(statusTemplateField);
            // Save template field
            TemplateField saveTemplateField = new TemplateField();
            saveTemplateField.ItemTemplate = new GridViewButtonTemplate();
            gvDetails.Columns.Add(saveTemplateField);
        }
        protected void BindData()
        {
            gvDetails.DataSource = data;
            gvDetails.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnSave = (Button)e.Row.FindControl("btnSave");
                if (btnSave != null)
                {
                    btnSave.CommandArgument = e.Row.RowIndex.ToString();
                }
            }
        }
        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
    }
