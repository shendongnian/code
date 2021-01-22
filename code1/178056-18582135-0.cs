                string TempFilename = Path.GetTempFileName();
                PdfReader pdfReader = new PdfReader(FileName);
                //PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(TempFilename, FileMode.Create));
                PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(TempFilename, FileMode.Create), '\0', true);
                
                AcroFields fields = stamper.AcroFields;
                AcroFields pdfFormFields = pdfReader.AcroFields;
                foreach (KeyValuePair<string, AcroFields.Item> kvp in fields.Fields)
                {
                    string FieldValue = GetXMLNode(XMLFile, kvp.Key);
                    if (FieldValue != "")
                    {
                        fields.SetField(kvp.Key, FieldValue);
                    }
                }
                stamper.FormFlattening = false;
                stamper.Close();
                pdfReader.Close()
