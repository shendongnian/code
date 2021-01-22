    using umbraco.presentation.nodeFactory;
    
    namespace cogworks.usercontrols
    {
    	public partial class ExampleUserControl : System.Web.UI.UserControl
    	{
            protected void Page_Load(object sender, EventArgs e)
            {
                //If you just want the children of the current node use the following method
                var currentNode = Node.GetCurrent();
    
                //If you need a specific node based on ID use this method (where 123 = the desired node id)
                var specificNode = new Node(123);
    
                //To get the children as a Nodes collection use this method
                var childNodes = specificNode.Children;
    
                //Iterating over nodes collection example
                foreach(var node in childNodes)
                {
                    Response.Write(string.Format("{0}<br />", node.Name));
                }
    	  
                //To get the nodes as a datatable so you can use it for DataBinding use this method
                var childNodesAsDataTable = node.ChildrenAsTable();
    
                //Databind example
                GridViewOnPage.DataSource = childNodesAsDataTable;
                GridViewOnPage.DataBind();
            }
    	}
    }
