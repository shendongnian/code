    using System;
    
    namespace SimpleWebTest
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e) { }
    
            protected void ClearButton_Click(object sender, EventArgs e)
            {
                using (ComplexOperationThingy cot = new ComplexOperationThingy())
                {
                    cot.DoSomethingComplex();
                }
            }
        }
    }
