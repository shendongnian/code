    <%@ Page Language="C#" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <script runat="server">
    
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			System.Collections.Generic.List<int> Values = new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7 };
    			grdTest.DataSource = Values;
    			grdTest.DataBind();
    		}
    	}
    
    	protected void btnSubmit_Click(object sender, EventArgs e)
    	{
    		HtmlInputCheckBox chkTest = null;
    		string SelectedValues = "";
    		foreach (GridViewRow row in grdTest.Rows)
    		{
    			chkTest = (HtmlInputCheckBox) row.FindControl("chkTest");
    			if (chkTest != null && chkTest.Checked)
    			{
    				SelectedValues += (SelectedValues == "" ? chkTest.Value : ", " + chkTest.Value);
    			}
    		}
    
    		litValues.Text = SelectedValues;
    	}
    </script>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
        		<asp:GridView ID="grdTest" runat="server">
    				<Columns>
    					<asp:TemplateField>
    						<ItemTemplate>
    							<input id="chkTest" type="checkbox" name="chkTest" runat="server" 
    							value="<%# (int)Container.DataItem %>" />
    						</ItemTemplate>
    					</asp:TemplateField>
    				</Columns>
    			</asp:GridView>
    			
    			<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Submit"  />
    			<br />
    			<asp:Literal ID="litValues" runat="server"></asp:Literal>
        </div>
        </form>
    </body>
    </html>
