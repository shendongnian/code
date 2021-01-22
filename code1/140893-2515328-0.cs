&lt;asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" DataKeyNames="UniqueID"
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging" >
&lt;Columns>
    &lt;asp:BoundField HeaderText="Remarks" DataField="Remarks" />
    &lt;asp:TemplateField HeaderText="Listing">
   &lt;<ItemTemplate>
        &lt;%# ShowListingTitle( <b>Convert.ToInt23(Eval("Field1")),Eval("Field2").ToString(),Eval("Field3").ToString()</b> ) %>
    &lt;/ItemTemplate>
    &lt;/asp:TemplateField>
   &lt;asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:C}" />
&lt;/Columns>
&lt;/asp:GridView>
