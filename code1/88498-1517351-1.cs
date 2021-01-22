    public static DisplayExtension
    {
        public static Display(this HtmlHelper html)
        {
            return new Display(html);
        }
    }
    
    
    public class Display // no longer static
    {
        private readonly HtmlHelper html;
    
        public string Display(HtmlHelper html)
        {
             this.html = html;
        }
    
        public string CheckBox()
        {
             return html.CheckBox("Test");
        }
    }
