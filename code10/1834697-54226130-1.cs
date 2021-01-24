   public string DisplayValue(Perm)
   {
             if (Perm)
             {
               return HiddenBankAcc;
            }
            else
            {
               return FullBankAcc;
            }
   }
2.) Assuming the value of variable "Perm" is in your gridview's datasource, on the aspx page
<asp:BoundField HeaderText="ABA">
   <asp:Label runat="server" Text='<%# DisplayValue((bool)Eval("Perm"))%>' </asp:Label>
</asp:BoundField>
