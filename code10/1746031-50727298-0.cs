    [ServiceContract]
    public interface IContract
    {
        [OperationContract, WebInvoke(UriTemplate = "UploadAttachments")]
        void UploadAttachments(Stream messageContent);
    }
    public class Service : IContract
    {
        public void UploadAttachments(Stream messageContent)
        {
            var xml = XElement.Load(messageContent);
            var hrefs = xml
                .Elements("ATTACHMENT")
                .Select(attachmentElement => attachmentElement.Attribute("href").Value);
            foreach (var href in hrefs)
            {
                Console.WriteLine(href);
            }
        }
    }
