    <asp:GridView ID="gvSelected" runat="server"
    
    AutoGenerateColumns = "false" Font-Names = "Arial"
    
    Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" 
    
    HeaderStyle-BackColor = "green" EmptyDataText = "No Records Selected"  >
    
    <Columns>
    
       <asp:BoundField DataField = "CustomerID" HeaderText = "Customer ID" />
    
       <asp:BoundField DataField = "ContactName" HeaderText = "Contact Name" />
    
       <asp:BoundField DataField = "City" HeaderText = "City" />
    
     </Columns>
    
    </asp:GridView>
    private void BindGridone()
    
    {
    
        string constr = ConfigurationManager
    
                    .ConnectionStrings["conString"].ConnectionString;
    
        string query = " select CustomerID, ContactName, City from customers";
    
        SqlConnection con = new SqlConnection(constr);
    
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
    
        DataTable dt = new DataTable();
    
        sda.Fill(dt);
    
        gvAll.DataSource = dt;
    
        gvAll.DataBind();
    
    }
