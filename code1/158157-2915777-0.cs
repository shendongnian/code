    [MessageContract]
    public class PDFRequest
    {
        [MessageHeader]
        public Enums.PDFDocumentNameEnum? docType { get; set; }
        [MessageHeader]
        public int? pk { get; set; }
        [MessageHeader]
        public string[] emailAddress { get; set; }
        [MessageBodyMember]
        public Kyle.Common.Contracts.TrackItResult[] trackItResults { get; set; }
    }
