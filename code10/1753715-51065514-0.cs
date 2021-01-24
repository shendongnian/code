	[XmlRoot(Namespace="http://tempuri.net/Phone.Messages")]
    public class CreateAuditLogEntry
    {
        public long SurveyId { get; set; }
        public int AuditEventId { get; set; }
        public System.DateTime EventDateTime { get; set; }
    }
