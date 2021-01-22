     public static XElement DictToXml
                      (Dictionary<string, string> inputDict, string elmName, string valuesName)
            {
                XElement outElm = new XElement(elmName);
                Dictionary<string, string>.KeyCollection keys = inputDict.Keys;
                XElement inner = new XElement(valuesName);
                foreach (string key in keys)
                {
                    inner.Add(new XAttribute("key", key));
                    inner.Add(new XAttribute("value", inputDict[key]));
                }
                outElm.Add(inner);
                return outElm;
            }
