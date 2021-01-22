    public static string SimpleCheckbox(this HtmlHelper helper, 
                                        string name, 
                                        string value, 
                                        bool isChecked)
    {
        return String.Format("<input type=\"checkbox\" name=\"{0}\" value=\"{1}\" " + (isChecked ? "checked" : "") + "/>", name, value);
    }
