    using (StringWriter stringWriter = new StringWriter())
    {
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        holder.RenderControl(htmlTextWriter);
        HttpContext.Response.Write(stringWriter.ToString());
        htmlTextWriter.Close();
        stringWriter.Close();
    }
