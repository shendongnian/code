    var table = new Table();
    //Add rows and cells
    
    var stringWriter = new StringWriter();
    using (var htmlWriter = new HtmlTextWriter(stringWriter)) {
        table.RenderControl(htmlWriter);
    }
    //To get the generated html, use stringWriter.ToString()
