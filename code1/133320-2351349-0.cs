    public class DynamicControl
    {
        public String BeginText { get; set; }
        public String EndText { get; set; }
        public String ControlName { get; set; }
        public Dictionary<String, String> ControlProperties { get; set; }
    }
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //read strings from db
            var dynamicControlStrings = GetStringsFromDB();
            //parse strings into list of dynamicControls
            var dynamicControls = ParseStringsToDynamicControls(dynamicControlStrings);
            foreach (var dynamicControl in dynamicControls)
            {
                CreateControl(dynamicControl.BeginText, dynamicControl.EndText, dynamicControl.ControlName, dynamicControl.ControlProperties);
            }
        }
    
        private void CreateControl(string beginText, string endText, string controlName, Dictionary<String, String> controlProperties)
        {
            var beginLabel = new Label()
            {
                Text = beginText
            };
    
            var dynamicControl = GenerateDynamicControl(controlName, controlProperties);        
    
            var endLabel = new Label()
            {
                Text = endText
            };
    
            var span = new HtmlGenericControl("span");
            span.Controls.Add(beginLabel);
            span.Controls.Add(dynamicControl);
            span.Controls.Add(endLabel);
    
            form1.Controls.Add(span);        
        }
    
        //you would create your dynamic control here (such as the hyperlink) based on the control name and use reflection to set the properties
        private WebControl GenerateDynamicControl(string controlName, Dictionary<String, String> controlProperties)
        {        
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }    
    }
