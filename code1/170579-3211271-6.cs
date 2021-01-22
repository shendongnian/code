    public class WrappedTreeNode : TreeNode
    {
        public string ClientValue { get; set; }
        protected override void RenderPreText(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            //you can simply use the base.Value aswell here if you want them to be the same
            writer.WriteAttribute("id", ClientValue);
            base.RenderPreText(writer);
        }
        protected override void RenderPostText(HtmlTextWriter writer)
        {
            base.RenderPostText(writer);
            writer.WriteEndTag("div");
        }        
    }
