    public class ColGroupGridView : GridView
    {
        private ColGroup _ColGroup = null;
        private ITemplate _ColGroupTemplate = null;
    
        [TemplateContainer(typeof(ColGroup))]
        public virtual ITemplate ColGroupTemplate
        {
            get { return _ColGroupTemplate; }
            set { _ColGroupTemplate = value; }
        }
    
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            _ColGroup = new ColGroup();
            ColGroupTemplate.InstantiateIn(_ColGroup);
        }
    
        protected override void Render(HtmlTextWriter writer)
        {
            // Get the base class's output
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            base.Render(htw);
            string output = sw.ToString();
            htw.Close();
            sw.Close();
    
            // Insert a <COLGROUP> element into the output
            int pos = output.IndexOf("<tr");
    
            if (pos != -1 && _ColGroup != null)
            {
                sw = new StringWriter();
                htw = new HtmlTextWriter(sw);
                _ColGroup.RenderPrivate(htw);
                output = output.Insert(pos, sw.ToString());
                htw.Close();
                sw.Close();
            }
    
            // Output the modified markup
            writer.Write(output);
        }
    }
    internal class ColGroup : WebControl, INamingContainer
    {
        internal void RenderPrivate(HtmlTextWriter writer)
        {
            writer.Write("<colgroup>");
            base.RenderContents(writer);
            writer.Write("</colgroup>");
        }
    }
