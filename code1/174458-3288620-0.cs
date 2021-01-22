    public static class UrlHelperExtensions
    {
        public static string AddToFavourites(this UrlHelper helper)
        {
            return helper.RouteUrl("AddToFavourites", new { url = EncodeUrl() });
        }
        private static string EncodeUrl()
        {
            var request = HttpContext.Current.Request;
            string url = request.Url.ToString();
            return Convert.ToBase64String(Encoding.Default.GetBytes(url));
        }
    }
