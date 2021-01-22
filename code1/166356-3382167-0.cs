    <%@ Page Title="Home Page" Language="C#" %>
    <div id="result"> 
        <asp:Repeater runat="server" id="results"> 
            <ItemTemplate> 
                <asp:Repeater runat="server" datasource='<%# ((WebPage)Container.DataItem).Links.Select ( link => new {
                                    Id = ((WebPage)Container.DataItem).Id, 
                                    Title = ((WebPage)Container.DataItem).Title, 
                                    Url = ((WebPage)Container.DataItem).Url, 
                                    URL = link.URL,
                                    URLType = link.URLType,
                                    URLState = link.URLState
                                    }) %>'> 
                    <ItemTemplate> 
                        <tr class="gradeX odd"> 
                            <td><%# Eval("Id") %></td> <!--property of WebPage (part of results repeater) -->
                            <td><%# Eval("Title") %></td> <!--property of WebPage (part of results repeater) -->
                            <td><%# Eval("Url") %></td> <!--property of WebPage (part of results repeater) -->
                            <td><%# Eval("URL") %></td><!--Property of Link -->
                            <td><%# Eval("URLType") %></td> <!--Property of Link--> 
                            <td><%# Eval("URLState") %></td> <!--Property of Link -->
                        </tr> 
                    </ItemTemplate> 
                    </asp:Repeater> 
            </Itemtemplate> 
        </asp:Repeater> 
    </div> 
    
    <script runat="server">
        public class Link
        {
            public string URL { get; set; }
            public int URLType { get; set; }
            public int URLState { get; set; }
        }
        public class WebPage
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
            public List<Link> Links { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            WebPage[] pages = new WebPage[] 
            {
                new WebPage { Id = "foo", 
                    Title = "foobar", 
                    Url = "http://foo.bar", 
                    Links = new List<Link> ( new Link[] {
                        new Link {URL = "http://something", URLType = 1, URLState = 2},
                        new Link {URL = "http://someotherthing", URLType = 3, URLState = 4}
                    })
                },
                new WebPage { Id = "excellent", 
                    Title = "excellent Title", 
                    Url = "http://excellent.com", 
                    Links = new List<Link> ( new Link[] {
                        new Link {URL = "http://excellent", URLType = 5, URLState = 6},
                        new Link {URL = "http://totallyexcellent", URLType = 7, URLState = 8}
                    })
                }
                
            };
            results.DataSource = pages;
            results.DataBind();
        }
    </script>
