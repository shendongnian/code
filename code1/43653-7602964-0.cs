        public static string ScriptBlock(this HtmlHelper html, string path)
        {
            return string.Format("<script src=\"{0}{1}\" type=\"text/javascript\"></script>\r\n", VirtualPathUtility.ToAbsolute(path), DateLastWriteFile(html.ViewContext.HttpContext.Server.MapPath(path)));
        }
        public static string CSSBlock(this HtmlHelper html, string path)
        {
            return string.Format("<link href=\"{0}{1}\" type=\"text/css\" rel=\"Stylesheet\" ></link>\r\n", VirtualPathUtility.ToAbsolute(path), DateLastWriteFile(html.ViewContext.HttpContext.Server.MapPath(path)));
        }
