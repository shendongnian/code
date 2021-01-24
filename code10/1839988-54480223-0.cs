        Write as below
         <Columns>
                <asp:TemplateField HeaderText="ApplicationNo">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblApplicationNo" runat="server" 
           data-applRefNo='<%#Eval("APPL_REF_NO") %>' Text = "Application Details" OnClick="btnApplicantDetails_Click"></asp:LinkButton>
                    </ItemTemplate>
                 </asp:TemplateField>
        </columns>
    
       protected void btnApplicantDetails_Click(object sender, EventArgs e)
       {
          string applRefno = btnApplicantDetails.attr("data-applRefNo");
            your coding here
       }
