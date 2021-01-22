    interface IRenderable
    {
        void Render(HtmlTextWriter writer);
    }
    class ListComponent : IRenderable
    {
        public List<IRenderable> Items { get; set; }
        public string Title { get; set; }
        public void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);
            writer.RenderBeginTag(HtmlTextWriterTag.Legend);
            writer.HtmlEncode(Title);
            writer.RenderEndTag();//end Legend
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "resultList");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            foreach (var item in Items)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                item.Render(writer);
                writer.RenderEndTag();//li
            }
            writer.RenderEndTag();//ul
            writer.RenderEndTag(); //fieldset
        }
    }
