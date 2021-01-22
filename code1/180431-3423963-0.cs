    class Helper
    {
        public static void SomeHelperMethod(Default page, string controlName)
        {
            Control control = page.Form.FindControl(controlName);
            if(control != null) { 
               // your code here
            }
        }
    }
