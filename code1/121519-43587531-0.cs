            static void Main(string[] args)
        {
            try
            {
                string xsdFileName = ConfigurationManager.AppSettings["configXsdPath"];
                string xmlFileName = args[0];
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add(null, xsdFileName);
                XDocument doc = XDocument.Load(xmlFileName);
                string validationMessage = string.Empty;
                doc.Validate(schemas, (sender, e) => { validationMessage += e.Message + Environment.NewLine; });
                if (validationMessage == string.Empty)
                {
                    Console.WriteLine("CONFIG FILE IS VALID");
                }
                else
                {
                    Console.WriteLine("CONFIG FILE IS INVALID : {0}", validationMessage);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EXCEPTION VALIDATING CONFIG FILE : {0}", ex.Message);
            }
        }
