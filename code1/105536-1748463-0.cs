    string userProvidedText               = uiTextBox.Text; // this is your textbox
    byte[] userProvidedTextAsBytes        = null;
    
    if (!string.IsNullOrEmpty(userProvidedText )) {
      System.Text.ASCIIEncoding encoding  = new System.Text.ASCIIEncoding();
      userProvidedTextAsBytes             = encoding.GetBytes(userProvidedText);
    }
    
    Response.AppendHeader("Content-Disposition", "attachment; filename=YourFileName.html");
    Response.ContentType = "text/HTML";
    Response.BinaryWrite(userProvidedTextAsBytes);
    Response.End();
