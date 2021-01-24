     protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
            {
                //NewEditIndex property used to determine the index of the row being edited.  
                gvBookStoreRecords.EditIndex = e.NewEditIndex;
                gridDataBind();
            }
            protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
            {
                //Finding the controls from Gridview for the row which is going to update  
                TextBox Name = gvBookStoreRecords.Rows[e.RowIndex].FindControl("Name") as TextBox;
                TextBox Birthdate = gvBookStoreRecords.Rows[e.RowIndex].FindControl("Birthdate") as TextBox;
                TextBox Gender = gvBookStoreRecords.Rows[e.RowIndex].FindControl("Gender") as TextBox;
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                gvBookStoreRecords.EditIndex = -1;
                //Call ShowData method for displaying updated data  
                gridDataBind();
            }
            protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
            {
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                gvBookStoreRecords.EditIndex = -1;
                gridDataBind();
            }    
    *--------------------------------------------------------------------------------*
        <asp:GridView ID="gvBookStoreRecords" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvBookStoreRecords_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit"   
          
        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>  
                        <asp:TemplateField>  
                            <ItemTemplate>  
                                <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                            </EditItemTemplate>  
                        </asp:TemplateField>
                    </Columns>  
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>*
