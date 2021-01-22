    <asp:Table runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server">foo
                    </asp:TextBox>
                    <asp:Button runat="server" />
                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow ID="TableRow1" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">
                                <asp:TextBox ID="TextBox1" runat="server">bar
                                </asp:TextBox>
                                <asp:Button ID="Button1" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Table ID="Table2" runat="server">
                                    <asp:TableRow ID="TableRow2" runat="server">
                                        <asp:TableCell ID="TableCell2" runat="server">
                                            <asp:TextBox ID="TextBox2" runat="server">hello
                                            </asp:TextBox>
                                            <asp:Button ID="Button2" runat="server" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Table ID="Table3" runat="server">
                                                <asp:TableRow ID="TableRow3" runat="server">
                                                    <asp:TableCell ID="TableCell3" runat="server">
                                                        <asp:TextBox ID="TextBox3" runat="server">world
                                                        </asp:TextBox>
                                                        <asp:Button ID="Button3" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
