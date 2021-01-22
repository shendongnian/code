    public class Service1 : IService1, IClientAccessPolicy
    {
        public IList<string> GetData(string value)
        {
            //Some logic
        }
        [OperationBehavior]
        public Stream GetPolicy()
        {
            const string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <access-policy>
                                            <cross-domain-access>
                                                <policy>
                                                    <allow-from http-request-headers=""*"">
                                                        <domain uri=""*""/>
                                                    </allow-from>
                                                    <grant-to>
                                                        <resource path=""/"" include-subpaths=""true""/>
                                                    </grant-to>
                                                </policy>
                                            </cross-domain-access>
                                        </access-policy>";
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }
