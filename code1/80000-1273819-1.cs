    private void MessageBox(string msg)
    {
        StringBuilder cstext2 = new StringBuilder();
        cstext2.Append("<script type=\"text/javascript\">");
        cstext2.Append("window.alert('" + msg + "')} </");
        cstext2.Append("script>");
        ClientScript.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);
    }
