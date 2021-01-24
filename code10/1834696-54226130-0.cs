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
<asp:TemplateField HeaderText="BankAcc">
    <ItemTemplate>
        <%# DisplayValue((bool)Eval("Perm"))%>
    </ItemTemplate>
</asp:TemplateField>
