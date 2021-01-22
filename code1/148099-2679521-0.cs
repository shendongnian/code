    public class MyTextBox: TextBox
    {
        public string DatePickerOptions { get; set; }
        
        public string DateFormatString { get; set; }
        public string EmptyDateText { get; set; }
        
        public DateTime? Date
        {
            get
            {
                DateTime? date = null;
                
                if ( string.IsNullOrEmpty(Text) )
                    return date;
                
                DateTime outDateTime;
                if (DateTime.TryParse(Text, out outDateTime))
                    date = outDateTime;
                return date;
            }
            set
            {
                DateTime? date = value;
                
                if ( date == null || ((DateTime)date).Year < 2 )
                    Text = EmptyDateText;
                else
                    Text = ((DateTime) date).ToString(DateFormatString);
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Text = EmptyDateText;
        }
        
        public override void RenderEndTag(System.Web.UI.HtmlTextWriter writer)
        {          
            StringBuilder javaScriptBuilder = new StringBuilder();
            javaScriptBuilder.Append("$(function() { $(\"#");
            javaScriptBuilder.Append(ClientID);
            javaScriptBuilder.Append("\").datepicker(");
            javaScriptBuilder.Append(DatePickerOptions);
            javaScriptBuilder.Append("); });");
            
            base.RenderEndTag(writer);
            writer.WriteLine();
            writer.Write("<script type=\"text/javascript\">");
            writer.WriteLine();
            writer.Indent++;
            writer.Write(javaScriptBuilder.ToString());
            writer.WriteLine();
            writer.Indent--;
            writer.Write("</script>");
            writer.WriteLine();
            writer.Close();
        }
    }
