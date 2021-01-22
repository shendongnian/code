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
    <dxwgv:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" AutoGenerateColumns="False" >
         <Columns>
             <dxwgv:GridViewDataTextColumn Caption="Name" FieldName="Name" ReadOnly="True">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Count" FieldName="Count" ReadOnly="True" >
             </dxwgv:GridViewDataTextColumn>
         </Columns>
         </dxwgv:ASPxGridView>
