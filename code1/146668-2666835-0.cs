    public static class MyHelperClass
    {
      public static string InputDisable(this HtmlHelper html, string name, string myValue,     bool isEnabled)
      {
        string show = "";
        if(!isEnable)
           show = "disabled = \"disabled\"";
        return "<input type = \"submit\" value = \"" + myValue + "\"" + show + " />";
      }
    }
