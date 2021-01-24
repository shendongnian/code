    public class XmlCustomBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                var parsedXml = actionContext.Request.Content.ReadAsStringAsync().Result;
                Regex regex = new Regex(@"<\?xml.*>", RegexOptions.Singleline);
                Match match = regex.Match(parsedXml);
                if (!match.Success) return false;
                parsedXml = match.Groups[0].Value;
                TextReader textReader = new StringReader(parsedXml);
                XDocument xDocument = XDocument.Load(textReader);
                bindingContext.Model = xDocument;
                return true;
            }
            catch(Exception ex)
            {
                bindingContext.ModelState.AddModelError("XmlCustomBinder", ex);
                return false;
            }
        }
    }
