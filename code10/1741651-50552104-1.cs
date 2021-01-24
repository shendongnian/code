    namespace Solutions{
        using System.Collections.Generic;
        using Newtonsoft.Json;
        public class EBaySearchBody{
            public class FindCompletedItemsRequest{
                [JsonProperty("keywords", Order = 1)]
                public string Keywords { get; set; }
    
                [JsonProperty("itemFilter",Order = 2)]
                public List<ItemFilter> ItemFilters { get; set; }
    
                [JsonProperty("outputSelector", Order = 3)]
                public List<string> OutputSelectors { get; set; }
    
                [JsonProperty("paginationInput", Order = 4)]
                public PaginationInput PaginationInput { get; set; }
            }
            public class PaginationInput{
                [JsonProperty("entriesPerPage", Order = 1)]
                public string EntriesPerPage { get; set; }
    
                [JsonProperty("pageNumber", Order = 2)]
                public string PageNumber { get; set; }
            }
            public class ItemFilter{
                [JsonProperty("name", Order = 1)]
                public string Name { get; set; }
    
                [JsonProperty("value", Order = 2)]
                public string Value { get; set; }
            }
            [JsonProperty("findCompletedItemsRequest")]
            public FindCompletedItemsRequest FindCompletedItemsRequestObject { get; set; }
            
            /// <summary>
            /// Create a <see cref="EBaySearchBody"/>object and serialize it to a JSON stream
            /// </summary>
            /// <returns></returns>
            public static string WriteFromObject()
            {
                //Create EbaySearchBody object.  
                EBaySearchBody searchBody = new EBaySearchBody(){
                        FindCompletedItemsRequestObject = new FindCompletedItemsRequest(){
                            Keywords = "searchtext",
                            ItemFilters = new List<ItemFilter>(){
                                new ItemFilter {
                                    Name = "SoldItemsOnly",
                                    Value = "true"
                                }
                            },
                            OutputSelectors = new List<string>(){
                                "PictureURLLarge",
                                "SellerInfo"
                            },
                            PaginationInput = new PaginationInput(){
                                EntriesPerPage = "100",
                                PageNumber = "1"
                            }
                        }
                    };
                return JsonConvert.SerializeObject(searchBody);
            }
        }
    }
