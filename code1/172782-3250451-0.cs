        using umbraco.presentation.nodeFactory;
        namespace cogworks.usercontrols
        {
            public partial class ExampleUserControl : System.Web.UI.UserControl
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                    var specificNode = new Node(1024);
                    var childNodes = specificNode.Children;
                
                    foreach(var node in childNodes)
                    {
                        if(node.NodeTypeAlias == "NewsItem")
                        {
                            //Do something with your NewsItem node!
                        }
                    }
                }
            }
        }
