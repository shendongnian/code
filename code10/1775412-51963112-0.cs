     public class Book
     {
            public string Id { get; set; }
            public string BookID { get; set; }
            public int Sunday { get; set; }
            public int Monday { get; set; }
            public int Tuesday { get; set; }
            public int Wednesday { get; set; }
            public int Thursday { get; set; }
            public int Friday { get; set; }
      }
             var result = (from item in itemList
                          group item by item.BookID into groupData
                          select new
                          {
                              BookID = groupData.Key,
                              MaxNo = (from sub in groupData
                                       select new int[]
                                       {
                                           sub.Sunday,
                                           sub.Monday,
                                           sub.Tuesday,
                                           sub.Wednesday,
                                           sub.Thursday,
                                           sub.Friday
                                       }).ToList()
                          }).ToList();
             
           //Get Max Element
           var finalResult= (from item in result
                            select new
                            {
                                item.BookID,
                                No = (from i in item.MaxNo
                                      from ii in i
                                      orderby ii descending
                                      select ii).FirstOrDefault()
                            });
