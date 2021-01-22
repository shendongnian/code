    htw.RenderBeginTag( HtmlTextWriterTag.Span );
    try
    {
       htw.Write(myObject.GenerateHtml());
    }
    catch (Exception e)
    {
       GenerateHtmlErrorMessage(htw);
    }
    finally
    {
       htw.RenderEndTag( );
    }
