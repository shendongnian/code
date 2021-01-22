    public static class HtmlHelperExt
    {
        public static HtmlString PostLink(this HtmlHelper html, string text, string action, object routeValues)
        {
            var tbForm = new TagBuilder("form");
            tbForm.MergeAttribute("method", "POST");
            tbForm.MergeAttribute("action", action);
            var inputDict = HtmlHelper.ObjectToDictionary(routeValues);
            var inputs = new List<string>();
            foreach (var key in inputDict.Keys)
            {
                const string inputFormat = @"<input type='hidden' name='{0}' value='{1}' />";
                var input = String.Format(inputFormat, key, html.Encode(inputDict[key]));
                inputs.Add(input);
            }
            var submitBtn = "<input type='submit' value='{0}'>";
            inputs.Add(String.Format(submitBtn, text));
            var innerHtml = String.Join("\n", inputs.ToArray());
            tbForm.InnerHtml = innerHtml;
            // return self closing
            return new MvcHtmlString(tbForm.ToString());
        }
    }
