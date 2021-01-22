            try
            {
                string strXaml = String.Empty;
                using (var reader = new System.IO.StreamReader(filePath, true))
                {
                    strXaml = reader.ReadToEnd();
                }
                object xamlContent = System.Windows.Markup.XamlReader.Parse(strXaml);
            }
            catch (System.Windows.Markup.XamlParseException ex)
            {
                // You can get specific error information like LineNumber from the exception
            }
            catch (Exception ex)
            {
                // Some other error
            }
