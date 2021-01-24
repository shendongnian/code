    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    
    namespace SoDeserializeJson_53936668
    {
        [System.Runtime.Serialization.DataContract]
        public class TimestampPackageDC
        {
            [DataMember]
            public string Timestamp { get; set; }
    
            [DataMember]
            public string Company { get; set; }
    
            [DataMember]
            public string ContactID { get; set; }
    
            [DataMember]
            public string Area { get; set; }
    
            [DataMember]
            public string PackageID { get; set; }
        } // end of class TimestampPackageDC
    
        [DataContract]
        public class TimestampPackageExtraDC : TimestampPackageDC
        {
            [DataMember]
            public IDictionary<string, string>[] ExtraInfo { get; set; }
        } // end of class TimestampPackageExtraDC
    
    
        [DataContract]
        public class GetAllUnprintedItemsResponse //: BaseResponse
        {
            [DataMember]
            public TimestampPackageDC[] TimestampPackages { get; set; }
    
            [DataMember]
            public TimestampPackageExtraDC[] TimestampExtraInfoPackages { get; set; }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
    
                var json = @"
                {
                    'DocumentException': null,
                    'Success': true,
                    'TimestampExtraInfoPackages': [{
                        'Area ': 'AA',
                        'Company': 'XXX',
                        'ContactID': '123',
                        'PackageID': 'P1',
                        'Timestamp': '20090501163433360001',
                        'ExtraInfo': [{
                                'Key': 'Key1',
                                'Value': 'value1'
                            },
                            {
                                'Key': 'Key2',
                                'Value': 'value2'
                            }
                        ]
                    }],
                    'TimestampPackages': []
                }".Replace("'","\"");
    
                GetAllUnprintedItemsResponse upResponse = new GetAllUnprintedItemsResponse();
    
                string responseData = json;
    
                var data = JsonConvert.DeserializeObject<GetAllUnprintedItemsResponse>(json);
    
                Console.WriteLine(data.TimestampExtraInfoPackages.First().ExtraInfo.Count());
    
            }
        }
    }
