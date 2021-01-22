    StringBuilder sb = new StringBuilder();
    using(HtmlTextWriter writer = new HtmlTextWriter(new StringWriter(sb)))
    {
        writer.WriteBeginTag("div");
        writer.WriteAttribute("class", "slide");
        //...
    }
    return sb.ToString();
