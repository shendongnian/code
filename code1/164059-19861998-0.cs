            PdfReader pdfReader = new PdfReader("c:\\ABC.pdf");
            string TempFilename = Path.GetTempFileName();
            AcroFields pdfFormFields = pdfReader.AcroFields;
            foreach (KeyValuePair<string, AcroFields.Item> kvp in pdfFormFields.Fields)
            {   
                    string fieldName = kvp.Key.ToString();
                    string fieldValue = pdfFormFields.GetField(kvp.Key.ToString());
                    Console.WriteLine(fieldName + " " + fieldValue);
            }
            pdfReader.Close();
