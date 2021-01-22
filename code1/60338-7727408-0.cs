    internal interface IReport
    {
        string[] Headers { get; }
    }
    abstract class Report : IReport
    {
        protected abstract string[] Headers { get; protected set; }
        string[] IReport.Headers
        {
            get { return Headers; }
        }
    }
    class OnlineStatusReport : Report
    {
        static string[] headers = new string[] { "Time", "Message" };
        protected internal override string[] Headers
        {
            get { return headers; }
            protected set { headers = value; }
        }
        internal OnlineStatusReport()
        {
            Headers = headers;
        }
    }
