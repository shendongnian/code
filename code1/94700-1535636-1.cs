    namespace System.Web.Mvc.Html
    {
        public static class GoogleChartHelpers
        {
            public static string GoogleChart(string cht, string chd, string chs, string chl)
            {
                return "<img source='http://chart.apis.google.com/chart?cht=" + cht 
                     + "&chd=" + chd + "&chs=" + chs + "&chl=" + chl + "' />;
            }
        }
    }
    
