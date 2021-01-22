    public class StackOverflow_2495195
    {
        [MessageContract(WrapperName="Browse", WrapperNamespace="urn:schemas-upnp-org:service:ContentDirectory:1", IsWrapped=true)]
        public class BrowseRequest
        {
            [MessageBodyMember(Namespace = "", Order = 0)]
            public string ObjectID;
            [MessageBodyMember(Namespace = "", Order = 1)]
            public string BrowseFlag;
            [MessageBodyMember(Namespace = "", Order = 2)]
            public string Filter;
            [MessageBodyMember(Namespace = "", Order = 3)]
            public ulong StartingIndex;
            [MessageBodyMember(Namespace = "", Order = 4)]
            public ulong RequestedCount;
            [MessageBodyMember(Namespace = "", Order = 5)]
            public string SortCriteria;
        }
        [MessageContract(WrapperName = "BrowseResponse", WrapperNamespace = "urn:schemas-upnp-org:service:ContentDirectory:1", IsWrapped = true)]
        public class BrowseResponse
        {
            [MessageBodyMember(Namespace = "", Order = 0)]
            public string Result;
            [MessageBodyMember(Namespace = "", Order = 1)]
            public ulong NumberReturned;
            [MessageBodyMember(Namespace = "", Order = 2)]
            public ulong TotalMatches;
            [MessageBodyMember(Namespace = "", Order = 3)]
            public ulong UpdateID;
        }
        [ServiceContract(Namespace = "urn:schemas-upnp-org:service:ContentDirectory:1")]
        public interface IContentDirectory
        {
            [OperationContract(Action = "urn:schemas-upnp-org:service:ContentDirectory:1#Browse")]
            //void Browse(string ObjectID, string BrowseFlag, string Filter, ulong StartingIndex, ulong RequestedCount, string SortCriteria, out string Result, out ulong NumberReturned, out ulong TotalMatches, out ulong UpdateID);
            BrowseResponse Browse(BrowseRequest request);
        }
        public class Service : IContentDirectory
        {
            //public void Browse(string ObjectID, string BrowseFlag, string Filter, ulong StartingIndex, ulong RequestedCount, string SortCriteria, out string Result, out ulong NumberReturned, out ulong TotalMatches, out ulong UpdateID)
            //{
            //    Result = null;
            //    NumberReturned = 0;
            //    TotalMatches = 0;
            //    UpdateID = 0;
            //}
            public BrowseResponse Browse(BrowseRequest request)
            {
                return new BrowseResponse { NumberReturned = 0, Result = null, TotalMatches = 0, UpdateID = 0 };
            }
        }
        static Binding GetBinding()
        {
            return new CustomBinding(
                new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8),
                new HttpTransportBindingElement());
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IContentDirectory), GetBinding(), "");
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<IContentDirectory> factory = new ChannelFactory<IContentDirectory>(GetBinding(), new EndpointAddress(baseAddress));
            IContentDirectory proxy = factory.CreateChannel();
            //string result;
            //ulong ul1, ul2, ul3;
            //proxy.Browse(null, null, null, 0, 0, null, out result, out ul1, out ul2, out ul3);
            proxy.Browse(new BrowseRequest { BrowseFlag = null, Filter = null, ObjectID = null, RequestedCount = 0, SortCriteria = null, StartingIndex = 0 });
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
