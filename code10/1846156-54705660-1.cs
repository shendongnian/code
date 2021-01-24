    [ServiceContract]
    [XmlSerializerFormat]
    public interface ICotractWithoutAttribute
    {
        [OperationContract]
    MyDataFather GetData(MyDataFather myDataFather);
    }
    public class CotractWithoutAttribute : ICotractWithoutAttribute
    {
        public MyDataFather GetData(MyDataFather myDataFather)
        {
            return myDataFather;
        }
    }
