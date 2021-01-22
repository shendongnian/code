    StringBuilder sb = new StringBuilder();
    StringWriter sWriter = new StringWriter(sb);
    HtmlTextWriter htmlWriter = new HtmlTextWriter(sWriter);
    MyUserControl uc = new MyUserControl();
    uc.RenderControl(htmlWriter);
    
    // The StringBuilder now has the control html output
    return sb.ToString();
