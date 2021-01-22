    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        try
        {
            RssSource.DataFile = "http://www.example.com/rss/feed/index1.aspx";
            RssSource.XPath = "/rss/channel/item[position()<3]";
            RssSource.EnableCaching = true;
            RssSource.CacheDuration = 43200;
            RssSource.CacheExpirationPolicy = DataSourceCacheExpiry.Absolute;
        }
        catch (Exception ex)
        {
            ErrorMessage.Visible = true;
            Repeater1.Visible = false;
    
        }
    }
    <asp:Label ID="ErrorMessage" runat="server" Text="News not unavailable" Visible="false" /> 
    <asp:XmlDataSource ID="RssSource" runat="server" />
    <asp:Repeater ID="repeater1" runat="server" DataSourceID="RssSource">
        <ItemTemplate>
            <p><%# XPath("description")%></p>
        </ItemTemplate>
    </asp:Repeater>  
  
