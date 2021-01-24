    public class Service1 : IService1
    {
        public BookingResult Booking(BookInfo bookInfo)
        {
            BookingResult result = new BookingResult();
            if (bookInfo==null)
            {
                result.isSucceed = false;
            }
            else
            {
                result.isSucceed = true;
            }
            return result;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class BookingResult
    {
        [DataMember]
        public bool isSucceed { get; set; }
