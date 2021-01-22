    <asp:TemplateField>
        <ItemTemplate>
            <asp:Label ID="lblstatus" runat="server" Text='<%# GetStatusText(Eval("status")) %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
  
    public string GetStatusText(string strIsActive)
            {
              bool val = Boolean.Parse(strIsActive);
              if(val)
              { 
                 return "Active";
              }
              else
              { 
                 return "Inactive";
              }
            }
