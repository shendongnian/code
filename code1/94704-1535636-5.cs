    namespace System.Web.Mvc.Html
    {
        public static class GoogleChartHelpers
        {
            public static string GoogleChart
                (string cht, string chd, string chs, string chl)
            {
                return "<img source='http://chart.apis.google.com/chart?cht=" + cht 
                     + "&amp;chd=" + chd 
                     + "&amp;chs=" + chs 
                     + "&amp;chl=" + chl + "' />;
            }
        }
    }
