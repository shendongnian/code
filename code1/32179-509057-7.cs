    #region WCFDataContractTest
        [DataContract] // The enclosed type needs to also be attributed for WCF
        public class RequestRecord
        {
            public RequestRecord() { }
            [DataMember] // This is CRUCIAL, otherwise the Name property will not be preserved.
            public string Name { get; set; }
        }
        [DataContract] // Encloses the RequestRecord type
        public class RequestArray
        {
            private int m_TotalRecords; // should be for internal bookkeeping only
            private RequestRecord[] m_Record;
            [System.Xml.Serialization.XmlElement]
            [DataMember]
            public RequestRecord[] Record
            {
                get { return m_Record; }
                // deserialization will not work without the set
                set { m_Record = value; }
            }
            [DataMember] // is not really needed
            public int TotalRecords
            {
                get { return m_TotalRecords; }
                set
                {
                    if (m_TotalRecords == 0)
                        m_TotalRecords = value;
                }
            }
            // The constructor is not called by the deserialization mechanism,
            // therefore this is the right place to specify the array size and to
            // perform the array initialization.
            public RequestArray(int totalRecords)
            {
                if (totalRecords > 0 && totalRecords <= 100)
                {
                    m_TotalRecords = totalRecords;
                    m_Record = new RequestRecord[totalRecords];
                    for (int i = 0; i < m_TotalRecords; i++)
                        m_Record[i] = new RequestRecord() { Name = "Record #" + i.ToString() };
                    m_TotalRecords = totalRecords;
                }
                else
                    m_TotalRecords = 0;
            }
        }
        public static void TestWCFDataContract()
        {
            var serializer = new DataContractSerializer(typeof(RequestArray));
            var test = new RequestArray(6);
            Trace.WriteLine("Array contents after 'new':");
            for (int i = 0; i < test.Record.Length; i++)
                Trace.WriteLine("\tRecord #" + i.ToString() + " .Name = " + test.Record[i].Name);
            //Modify the record values...
            for (int i = 0; i < test.Record.Length; i++)
                test.Record[i].Name = "Record (Altered) #" + i.ToString();
            Trace.WriteLine("Array contents after modification:");
            for (int i = 0; i < test.Record.Length; i++)
                Trace.WriteLine("\tRecord #" + i.ToString() + " .Name = " + test.Record[i].Name);
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, test);
                ms.Flush();
                ms.Position = 0;
                var newE = serializer.ReadObject(ms) as RequestArray;
                Trace.WriteLine("Array contents upon deserialization:");
                for (int i = 0; i < newE.Record.Length; i++)
                    Trace.WriteLine("\tRecord #" + i.ToString() + " .Name = " + newE.Record[i].Name);
            }
        }
    #endregion
