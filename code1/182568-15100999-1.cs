    <asp:GridView ID="gvExample" runat="server" AutoGenerateColumns="False" OnDataBound="gvExample_DataBound">
      <Columns>
        <asp:TemplateField HeaderText="Department">
          <EditItemTemplate>
            <asp:DropDownList ID="ddlDepartment_Edit" runat="server" DataSourceID="dsDepartment_Edit"
              DataTextField="DepartmentName" DataValueField="PK_DepartmentId">
            </asp:DropDownList>
            <asp:HiddenField ID="hfDepartmentId" runat="server" Value='<%# Bind("PK_DepartmentId") %>' />
            <asp:SqlDataSource ID="dsDepartment_Edit" runat="server" ConnectionString="<%$ ConnectionStrings:BlackHillsConnect %>"
              ProviderName="System.Data.SqlClient" SelectCommand="sp_GetDepartmentDropDown" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
          </EditItemTemplate>
          <ItemTemplate>
            <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("DepartmentName") %>'>
            </asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Button" />
      </Columns>
    </asp:GridView>
    protected void gvExample_DataBound(object sender, EventArgs e)
    {
      foreach (GridViewRow gvRow in gvExample.Rows)
      {
        DropDownList ddlDepartment = gvRow.FindControl("ddlDepartment_Edit") as DropDownList;
        HiddenField hfDepartmentId = gvRow.FindControl("hfDepartmentId") as HiddenField;
    
        if (ddlDepartment != null && hfDepartmentId != null)
        {
          ddlDepartment.SelectedValue = hfDepartmentId.Value;
        }
      }
    }
