    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    
    namespace NerdDinner.Views
    {
        public class NerdDinnerViewPage<T> : ViewPage<T> where T : class
        {
            protected override void InitializeCulture()
            {
                base.InitializeCulture();
    
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentCulture.Clone() as CultureInfo;
    
                if (Thread.CurrentThread.CurrentCulture != null)
                {
                    Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
                    Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
                }
            }
        }
    }
