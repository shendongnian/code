                using (TextWriter writer = new StreamWriter(ConfigurationManager.AppSettings["downloadFilePath"] + ConfigurationManager.AppSettings["fileName"] + date + ConfigurationManager.AppSettings["csvExtension"].ToString()))
                {
                    using (var csv = new CsvWriter(TextWriter.Synchronized(writer)))
                    {
                        csv.WriteHeader(typeof(DataInformation));
                        csv.NextRecord();
                        csv.WriteRecords(dataInformation);
                    }
                }
