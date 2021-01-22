            foreach (HeaderPart header in doc.MainDocumentPart.HeaderParts)
            {
                string headerText = null;
                using (StreamReader sr = new StreamReader(header.GetStream()))
                {
                    headerText = sr.ReadToEnd();
                }
                headerText = DoTheReplace(properties, headerText);
                using (StreamWriter sw = new StreamWriter(header.GetStream(FileMode.Create)))
                {
                    sw.Write(headerText);
                }
               
                //Save Header
                header.Header.Save();
            }
