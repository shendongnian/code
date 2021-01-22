    public class Inquiries
    {
        private SqlParameter[] _parameters;
        public DateTime FromDate { get{ //return value from parameters array} set{ // add a new parameter to your array } }
        public DateTime ToDate { get{ //return value from parameters array} set{ // add a new parameter to your array } }        public String Subject { get; set{ // add a new parameter to your array } }
        public String Press { get{ //return value from parameters array} set{ // add a new parameter to your array } }        public String Cia { get; set{ // add a new parameter to your array } }
        public String Media { get{ //return value from parameters array} set{ // add a new parameter to your array } }
        public List<Inquiry> Get()
        {
            // Your dal code using the parameters array
        }
    }
