    public static class MyOtherClassExtensions
    {
        public static string GetText(this MyOtherClass parent)
        {
            using(var helper = parent.CreateHelper())
            {
               return helper.Text;
            }
        }
    }
