    namespace My.Namespace.Controls
    {
    [ToolboxData("<{0}:MyDropDownList runat=\"server\"></{0}:MyDropDownList>")]
    public class MyDropDownList: DropDownList
    {
        // your custom code goes here
        // e.g.
        protected override void  RenderContents(HtmlTextWriter writer)
        {
            //Your own render code
        }
    }
    }
