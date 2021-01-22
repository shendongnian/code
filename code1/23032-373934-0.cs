    private static void TraceMethodArguments(MethodExecutionEventArgs eventArgs)
        {
            object[] parameters = eventArgs.GetReadOnlyArgumentArray();
            if (parameters != null)
            {
                string paramValue = null;
                foreach (object p in parameters)
                {
                    Type _type = p.GetType();
                    if (_type == typeof(string) || _type == typeof(int) || _type == typeof(double) || _type == typeof(decimal))
                    {
                        paramValue = (string)p;
                    }
                    else if (_type == typeof(XmlDocument))
                    {
                        paramValue = ((XmlDocument)p).OuterXml;
                    }
                    else
                    { //try to serialize
                        try
                        {
                            XmlSerializer _serializer = new XmlSerializer(p.GetType());
                            StringWriter _strWriter = new StringWriter();
                            _serializer.Serialize(_strWriter, p);
                            paramValue = _strWriter.ToString();
                        }
                        catch
                        {
                            paramValue = "Unable to Serialize Parameter";
                        }
                    }
                    Trace.TraceInformation("[" + Process.GetCurrentProcess().Id + "-" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + " Parameter: " + paramValue);
                }
            }
        }
