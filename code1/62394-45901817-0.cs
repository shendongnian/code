    protected override void Render(HtmlTextWriter output)
        {
            StringWriter stringWriter = new StringWriter();
    
            HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
            base.Render(textWriter);
    
            textWriter.Close();
    
            string strOutput = stringWriter.GetStringBuilder().ToString();
    
            strOutput = Regex.Replace(strOutput, "<input[^>]*id=\"__VIEWSTATE\"[^>]*>", "", RegexOptions.Singleline);
    
            output.Write(strOutput);
        }
