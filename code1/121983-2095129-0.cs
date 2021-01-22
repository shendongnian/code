    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="button1" />
        </Triggers>
        <ContentTemplate>
            ...
            <asp:Button ID="button1" runat="server" Text="Click Me" />
        </ContentTemplate>
    </asp:UpdatePanel>
