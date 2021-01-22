    public class Item
    {
      public string Name { get; set; }
      public int Count { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      GridView1.DataSource = new Item[] { new Item { Name = "2", Count = 2 }, new Item { Name = "3", Count = 3 }, };
      GridView1.DataBind();
    }
    <asp:GridView ID="GridView1" runat="server">
      </asp:GridView>
