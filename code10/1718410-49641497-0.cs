    class Program
        {
            public static void AddListFromSchema(string listName, string listUrl, string webUrl, string schemaXml, int listTemplateType, bool listQuickLaunch, string listDescription)
            {
                //read document
                XDocument doc = XDocument.Parse(schemaXml);
                XElement root = doc.Root;
    
                ////get basic list attributes            
                //int listTemplateType = Convert.ToInt32(root.Attribute("ListTemplateType").Value);
                //bool listQuickLaunch = Convert.ToBoolean(root.Attribute("OnQuickLaunch").Value);
                //string listDescription = root.Attribute("Description").Value;
    
                //get fields
                IEnumerable<XElement> xFields = root.Elements("Fields").Elements("Field");
    
                if (string.IsNullOrEmpty(webUrl) || string.IsNullOrEmpty(listUrl))
                {
                    throw new ArgumentNullException("webUrl or listUrl cannot be empty");
                }
                else if (string.IsNullOrEmpty(listName))
                {
                    listName = listUrl;
                }
    
                ClientContext context = new ClientContext(webUrl);
                Web web = context.Web;
                IEnumerable<List> result = context.LoadQuery(web.Lists.Where(myList => myList.Title == listName));
                context.ExecuteQuery();
    
    
                //Create list if doesn't exist
                List list = result.FirstOrDefault();
                if (list == null)
                {
                    ListCreationInformation creationInfo = new ListCreationInformation();
    
                    creationInfo.Title = listName;
                    creationInfo.Url = listUrl;
                    creationInfo.TemplateType = listTemplateType;
                    list = web.Lists.Add(creationInfo);
                    list.Description = listDescription;
                    list.OnQuickLaunch = listQuickLaunch;
    
                    list.Update();
    
                    context.ExecuteQuery();
                    //Add fields
                    foreach (XElement xField in xFields)
                    {
                        string fldName = xField.Attribute("Name").Value;
                        string fldDisplayName = xField.Attribute("DisplayName").Value;
    
                        IEnumerable<Field> fields = context.LoadQuery(list.Fields.Include(f => f.InternalName));
                        context.ExecuteQuery();
    
                        Field existingField = fields.FirstOrDefault(f => f.InternalName == fldName);
                        if (existingField == null)
                        {
                            string fieldXml = Regex.Replace(xField.ToString(), fldDisplayName, fldName);
    
                            //internal name is derived from 'DisplayName' ('InternalName' attribute not working), DisplayName is overriden later as 'Title'
                            Field fld = list.Fields.AddFieldAsXml(fieldXml, true, AddFieldOptions.DefaultValue);
                            fld.Title = fldDisplayName;
    
                            fld.Update();
                            context.ExecuteQuery();
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                using (var oClientContext = new ClientContext("http://sp:12001"))
                {
                    // load the properties of web project
                    Web oWeb = oClientContext.Web;
                    // Get the people list in the web
                    List sourceList = oClientContext.Web.Lists.GetByTitle("people");
                    oClientContext.Load(oWeb, web => web.Url);
                    oClientContext.Load(sourceList, list => list.SchemaXml, list => list.BaseTemplate);
                    oClientContext.ExecuteQuery();
    
                    //ListCreationInformation creationInfo = new ListCreationInformation();
                    //creationInfo.Title = "persons";
                    //creationInfo.Description = "new list created using VS 2013 &CSOM";
                    //creationInfo.CustomSchemaXml = sourceList.SchemaXml;
                    //creationInfo.TemplateType = (int)ListTemplateType.GenericList;
                    //List newList = oClientContext.Web.Lists.Add(creationInfo);
    
                    //oClientContext.Load(newList);
                    //oClientContext.ExecuteQuery();
    
                    AddListFromSchema("persons", "Lists/persons", oWeb.Url, sourceList.SchemaXml, (int)ListTemplateType.GenericList, true, "new list created using VS 2013 &CSOM");
                    Console.WriteLine("done");
                    Console.ReadKey();
                }
            }
        }
