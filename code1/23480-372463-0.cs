    <%@ Page Language="C#" AutoEventWireup="true"%>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script runat="server">
        public class Class1
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public Class2 Class2Ref { get; set; }
        }
    
        public class Class2
        {
            public string ID2 { get; set; }
            public string Name2 { get; set; }
        }
            
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myGrid.DataSource = new[] 
                { 
                    new Class1() 
                    {
                        ID = "1",
                        Name = "Name1",
                        Class2Ref = new Class2() 
                        {
                            ID2 = "IDRef1",
                            Name2 = "NameRef1"
                        }
                    },
                    new Class1() 
                    {
                        ID = "2",
                        Name = "Name2",
                        Class2Ref = new Class2() 
                        {
                            ID2 = "IDRef2",
                            Name2 = "NameRef2"
                        }
                    }
                };
                myGrid.DataBind();
            }
        }
    </script>
    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>Untitled Page</title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:DataGrid runat="server" ID="myGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            ID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("ID") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            ID2
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Class2Ref.ID2") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            Name2
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Class2Ref.Name2") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </div>
        </form>
    </body>
    </html>
