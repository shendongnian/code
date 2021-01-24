     <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell onclick="tablecell_click();">
                hello
            </asp:TableCell>
       </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" id="btnCellClick" OnClick="Table1_Click"/>
        <script>
            function tablecell_click() {
               $('#btnCellClick').click();
             }
       </script>
