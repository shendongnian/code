    using (StreamReader sr = new StreamReader(filePath))
                    {
                        var csvReader = new CsvReader(sr);
                        var records = csvReader.GetRecords<object>();
                        var result = string.Empty;
                        try
                        {
                            return JsonConvert.SerializeObject(new ServerData(records, _eventMessage));
                        }
                        catch (Exception ex)
                        {
                            _eventMessage.Level = EventMessage.EventLevel.Error;
                        }
    
    
                        return _serializer.Serialize(new ServerData(result, _eventMessage));
                    }
