        // Regex to find only the language code part of the URL
        static readonly Regex removeLanguage = new Regex(@"/[a-z]{2}|[a-z]{2}-[a-zA-Z]{2}/", RegexOptions.Compiled);
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                // Decode the return URL and remove any language selector from it
                id = Server.UrlDecode(id);
                id = removeLanguage.Replace(id, @"/");
                return Redirect(id);
            }
            return Redirect(@"/");
        }
