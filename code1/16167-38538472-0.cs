        public void Keep<TValue>(TValue item, string path)
        {
            try
            {
                using (var stream = File.Open(path, FileMode.Create))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    try
                    {
                        using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream, Encoding.UTF8, true, true, "  "))
                        {
                            var serializer = new DataContractJsonSerializer(type, Settings);
                            serializer.WriteObject(writer, item);
                            writer.Flush();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                    }
                    finally
                    {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }
