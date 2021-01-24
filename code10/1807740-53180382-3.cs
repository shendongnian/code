    public class ApiJsonView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            viewContext.HttpContext.Response.AddHeader("Content-Type", "application/json");
            //Json.NET, normaly included in MVC
            var serializer = JsonSerializer.Create();
            serializer.Serialize(writer, viewContext.ViewData.Model);
        }
    }
    public class ApiXmlView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            viewContext.HttpContext.Response.AddHeader("Content-Type", "application/xml");
            var model = viewContext.ViewData.Model;
            var serializer = new DataContractSerializer(model.GetType());
            using (var xmlWriter = new XmlTextWriter(writer))
            {
                serializer.WriteObject(xmlWriter, model);
            }
        }
    }
