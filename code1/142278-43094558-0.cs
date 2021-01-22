     public static T MyDeepCopy<T>(this T source)
                {
                    try
                    {
        
                        //Throw if passed object has nothing
                        if (source == null) { throw new Exception("Null Object cannot be cloned"); }
        
                        // Don't serialize a null object, simply return the default for that object
                        if (Object.ReferenceEquals(source, null))
                        {
                            return default(T);
                        }
        
                        //variable declaration
                        T copy;
                        var obj = new DataContractSerializer(typeof(T));
                        using (var memStream = new MemoryStream())
                        {
                            obj.WriteObject(memStream, source);
                            memStream.Seek(0, SeekOrigin.Begin);
                            copy = (T)obj.ReadObject(memStream);
                        }
                        return copy;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
