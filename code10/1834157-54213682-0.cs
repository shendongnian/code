public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var dataObjects = new List<DataObject>();
                for (int i = 0; i < 100; i++)
                {
                    dataObjects.Add(new DataObject() { Index = i });
                }
                gridView1.DataSource = dataObjects;
                gridView1.DataBind();
            }
        }
        protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var dataObjectIndex = int.Parse((string) e.CommandArgument);
                e.Handled = true;
            }
        }
    }
    public class DataObject
    {
        public int Index { get; set; }
    }
    <asp:GridView ID="gridView1" runat="server" OnRowCommand="gridView1_RowCommand" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Index" HeaderText="Index" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Bind("Index") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
