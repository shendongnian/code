     public static bool Validate(string xsd, string xmlFrag)
        {
            if (string.IsNullOrEmpty(xmlFrag))
                return false;
    
            Trace.Indent();
    
            XmlValidatingReader reader = null;
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            ValidationEventHandler eventHandler = new ValidationEventHandler(ShowCompileErrors);
    
            try
            {
                //Create the XmlParserContext.
                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);
    
                //Implement the reader. 
                reader = new XmlValidatingReader(xmlFrag, XmlNodeType.Element, context);
                //Add the schema.
                myschema.Add("", xsd);
    
                //Set the schema type and add the schema to the reader.
                reader.ValidationType = ValidationType.Schema;
                reader.Schemas.Add(myschema);
    
                while (reader.Read())
                {
                }
    
                Trace.WriteLine("Completed validating xmlfragment");
                return true;
            }
            catch (XmlException XmlExp)
            {
                Trace.WriteLine(XmlExp.Message);
            }
            catch (XmlSchemaException XmlSchExp)
            {
                Trace.WriteLine(XmlSchExp.Message);
            }
            catch (Exception GenExp)
            {
                Trace.WriteLine(GenExp.Message);
            }
            finally
            {
                Trace.Unindent();
            }
            return false;
    
        }
        public static void ShowCompileErrors(object sender, ValidationEventArgs args)
        {
            Trace.WriteLine("Validation Error: {0}", args.Message);
        }
