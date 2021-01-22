        private SPListItemCollection GetItemsByEventType()
        {
            HttpContextHelper.ResetCurrent();
            SPList list;
            try
            {
                SPWeb web = Context.Site.OpenWeb(Context.Web.ID);
                try
                {
                    list = web.Lists[ListName];
                }
                catch (Exception)
                {
                    list = web.GetListFromUrl(ListName);
                }
                if (!String.IsNullOrEmpty(ListViewName))
                {
                    SPView view = list.Views.Cast<SPView>()
                        .Where(t => t.Title == ListViewName)
                        .FirstOrDefault();
                    return list.GetItems(view);
                }
            } finally
            {
                HttpContextHelper.RestoreCurrent();
            }
            return list.Items;
        }
        protected new SPContext Context
        {
            get { return SPContext.GetContext(base.Context); }
        }
    public class HttpContextHelper
    {
        #region Fields
        [ThreadStatic]
        private static HttpContext _current;
        #endregion
        #region Methods
        public static void ResetCurrent()
        {
            if (_current != null)
            {
                throw new InvalidOperationException();
            }
            _current = HttpContext.Current;
            HttpContext.Current = null;
        }
        public static void RestoreCurrent()
        {
            HttpContext.Current = _current;
            _current = null;
        }
        #endregion
    }
