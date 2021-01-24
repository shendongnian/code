    public class SwaggerConfig
    {
        public static void Register()
        {
            var customHeader = new SwaggerHeader  //you can ignore this one
            {
                Description = "Custom header description",
                Key = "customHeaderId",
                Name = "customHeaderId"
            };
            var versionSupportResolver = new Func<ApiDescription, string, bool>((apiDescription, version) =>
            {
                var path = apiDescription.RelativePath.Split('/');
                var pathVersion = path[1];
                return string.Equals(pathVersion, version, StringComparison.OrdinalIgnoreCase);
            });
            var versionInfoBuilder = new Action<VersionInfoBuilder>(info => {
                info.Version("v2", "My API v2");
                info.Version("v1", "My API v1");
            });
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    //c.RootUrl(ComputeHostAsSeenByOriginalClient);  //you can ignore this custom function
                    c.Schemes(new[] { "http", "https" });
                    customHeader.Apply(c);
                    c.MultipleApiVersions(versionSupportResolver, versionInfoBuilder);
                    c.IgnoreObsoleteActions();
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi("swagger/ui/{*assetPath}", c =>
                {
                    c.DisableValidator();
                    c.SupportedSubmitMethods("GET", "POST");
                });
        }
        private static Func<XPathDocument> GetXmlCommentsPath()
        {
            return () =>
            {
                var xapixml = GetXDocument("My.API.xml");
                var xElement = xapixml.Element("doc");
                XPathDocument xPath = null;
                if (xElement != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        var xws = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false };
                        using (var xw = XmlWriter.Create(ms, xws))
                        {
                            xElement.WriteTo(xw);
                        }
                        ms.Position = 0;
                        xPath = new XPathDocument(ms);
                    }
                }
                return xPath;
            };
        }
        private static XDocument GetXDocument(string file)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            var xDoc = XDocument.Load(path + "\\" + file);
            return xDoc;
        }
        
        //ComputeHostAsSeenByOriginalClient function code
    }
