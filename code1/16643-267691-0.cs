            // or long-hand in C# 2.0
            ParameterClass pc = new ParameterClass {
                Data = new List<ParmData> { new ParmData {
                    Value = new MyDictionary  {
                        {"abc",123},
                        {"def","ghi"}
                    }}}};
            DataContractSerializer dcs = new DataContractSerializer(pc.GetType());
            string xml;
            using(StringWriter sw = new StringWriter())
            using(XmlWriter xw = XmlWriter.Create(sw)) {
                dcs.WriteObject(xw, pc);
                xw.Close();
                xml = sw.ToString();
            }
            using(StringReader sr = new StringReader(xml)) {
                ParameterClass clone = (ParameterClass)dcs.ReadObject(XmlReader.Create(sr));
                Console.WriteLine(clone.Data.Count);
                Console.WriteLine(clone.Data[0].Value.GetType().Name);
                MyDictionary d = (MyDictionary)clone.Data[0].Value;
                foreach (KeyValuePair<string, object> pair in d)
                {
                    Console.WriteLine("{0}={1}", pair.Key, pair.Value);
                }
            }
