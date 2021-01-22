    <%@ Page Language="C#" %>
    <script runat="server">
    protected void  Page_Load(object sender, EventArgs e)
    {
        CategoriesList.DataBind();
    }
    class Category
    {
        public string CategoryName { get; set; }
        public string GetProperty() { return CategoryName; }
        public string[] Items { get { return new string[] {CategoryName + " 1", CategoryName + " 2"}; } }
    }
    Category[] Categories = new Category[]
    {
        new Category { CategoryName = "Shorts" },
        new Category { CategoryName = "Socks" },
        new Category { CategoryName = "Shirts" },
    };
    </script>
    <html>
    <body>
    <asp:Repeater runat="server" ID="CategoriesList" DataSource="<%# Categories %>">
      <ItemTemplate>
        <uc:ItemsControl 
           Items="<%# ((Category)(Container.DataItem)).Items %>" 
           OtherProperty="<%# ((Category)(Container.DataItem)).GetProperty() %>" 
           runat="server"/>
      </ItemTemplate>       
    </asp:Repeater>
    </body>
    </html>
