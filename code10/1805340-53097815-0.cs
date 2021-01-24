    using System;
    namespace Test
    {
        public partial class TestPage : System.Web.UI.Page
        {
            public int[] p = { 999999999, 999999999, 999999999, 999999999, 999999999 };
            protected void Page_Load(object sender, EventArgs e)
            {
                long s = Sum;
            }
            public long Sum
            {
                get { long s = 0; Array.ForEach(p, delegate (int i) { s += i; }); return s; }
            }        
        }
    }
