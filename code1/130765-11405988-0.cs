    using System.Collections.Generic;
    using System.Xml.Serialization;
    namespace TestLoadingMultiXml
    {
    [XmlRoot(ElementName=@"main")]
    public class XmlMain
    {
        private XmlDataTest data;
        [XmlElement(ElementName=@"datalist")]
        public XmlDataTest Data
        {
            get { return data; }
            set { data = value; }
        } // public XmlDataTest Data
        public XmlMain()
        {
            data = new XmlDataTest();
        }
    }
    [XmlRoot(ElementName=@"xmldata")]
    public class XmlDataTest
    {
        private List<DataDetails> listData;
        [XmlElement(ElementName=@"listdata")]
        public List<DataDetails> Data
        {
            get { return listData; }
            set { listData = value; }
        }
        public XmlDataTest()
        {
            listData = new List<DataDetails>();
            for (int i = 0; i < 10; i++)
            {
                DataDetails d = new DataDetails(string.Format("{0}", i));
                listData.Add(d);
            } // for (int i=0; i < 10; i++)
        } // public XmlDataTest()
    } // class XmlDataTest
    [XmlRoot(ElementName=@"datadetail")]
    public class DataDetails
    {
        private string name;
        [XmlAttribute(AttributeName=@"name")]
        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }
        public DataDetails(string _value)
        {
            this.name = _value;
        } // public DataDetails(string _value)
        public DataDetails()
        {
            this.name = "";
        } // public DataDetails()
    } // public class DataDetails
    }
