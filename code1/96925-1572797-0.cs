    private void RenderList<T>(HtmlTextWriter writer, string title, string headerText, List<T> objectsToRender) where T : IRender
    {
        writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);
        writer.RenderBeginTag(HtmlTextWriterTag.Legend);
        writer.HtmlEncode(title);
        writer.RenderEndTag();//end Legend
        writer.AddAttribute(HtmlTextWriterAttribute.Class, "resultList");
        writer.RenderBeginTag(HtmlTextWriterTag.Ul);
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div); //begin Header
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "header");
            writer.HtmlEncode(headerText);
            writer.RenderEndTag(); //end Header
            // render all objects
            foreach (T obj in objectsToRender)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li); // begin Custom Object Rendering
                obj.CustomRender(writer);
                writer.RenderEndTag(); // end Custom Object Rendering
            }
        }
        writer.RenderEndTag();//ul
        writer.RenderEndTag(); //fieldset
    }
    // IRender interface
    public interface IRender
    {
        void CustomRender(HtmlTextWriter writer);
    }
