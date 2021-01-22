    DataContractSerializer ser =
                        new DataContractSerializer(typeof(Client));
                    var ms = new System.IO.MemoryStream();
    
                    ser.WriteObject(ms, r);
    
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
    
    
    
                    var sr = new System.IO.StreamReader(ms);
    
                    var xml = sr.ReadToEnd();
