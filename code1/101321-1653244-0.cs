    using System.Xml;
    using System.IO;
    using System.Data;
    
    namespace TestStaticXMLDataSet
    {
        public static class DataSetClass
        {
            internal static DataSet _dataSet;
    
            public static void setDataSet(DataSet incomingDataSet)
            {
                _dataSet = incomingDataSet;
            }
    
            public static DataSet getDataSet()
            {
                return _dataSet;
            }
    
            public static void readXMLintoDataSet(string filePath)
            {
                if (_dataSet == null)
                {
                    _dataSet = new DataSet();
                }
                else
                {
                    _dataSet.Clear();
                }
    
                _dataSet.ReadXml(filePath);
            }
    
            public static void writeDataSetToXML(string filePath)
            {
                if (_dataSet == null)
                {
                    return;
                }
                else
                {
                    _dataSet.WriteXml(filePath);
                }
            }
        }
    }
