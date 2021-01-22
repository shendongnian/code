        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);
            writer.Write(HtmlTextWriter.TagLeftChar); // '<'
            writer.Write(this.TagName);
            writer.Write(HtmlTextWriter.SpaceChar); // ' '
            writer.WriteAttribute("uid", "00101010101");
            writer.Write(HtmlTextWriter.SpaceChar); // ' '
            writer.Write(HtmlTextWriter.SelfClosingTagEnd); // "/>"
        }
