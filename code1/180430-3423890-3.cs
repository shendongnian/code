    class Helpers
    {
        public static void YourHelperMethod(Page page)
        {
            //You can access your controls here like:
            Label label = page.FindControl("labelName") as Label;
            if (label == null)
                //The control could not be found
            label.Text = "Some text";
        }
    }
