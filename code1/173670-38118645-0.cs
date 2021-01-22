    protected override void Render(HtmlTextWriter writer)
    {
            // *** Write the HTML into this string builder
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hWriter = new HtmlTextWriter(sw);
            base.Render(hWriter);
            // *** store to a string
            string PageResult = sb.ToString(); //PageResult contains the HTML
            // *** Write it back to the server
            writer.Write(PageResult)
    }
