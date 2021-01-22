    var arraylist = new List<List<dynamic>>();
            List<dynamic> messages = new List<dynamic>
            {
                new { FcntUp = 101, CommTimestamp = "2019-01-01 00:00:01" },
                new { FcntUp = 102, CommTimestamp = "2019-01-01 00:00:02" },
                new { FcntUp = 103, CommTimestamp = "2019-01-01 00:00:03" },
                //restart of sequence
                new { FcntUp = 1, CommTimestamp = "2019-01-01 00:00:04" },
                new { FcntUp = 2, CommTimestamp = "2019-01-01 00:00:05" },
                new { FcntUp = 3, CommTimestamp = "2019-01-01 00:00:06" },
                
                //restart of sequence
                new { FcntUp = 1, CommTimestamp = "2019-01-01 00:00:07" },
                new { FcntUp = 2, CommTimestamp = "2019-01-01 00:00:08" },
                new { FcntUp = 3, CommTimestamp = "2019-01-01 00:00:09" }
            };
            //group by FcntUp and CommTimestamp
            var query = messages.GroupBy(x => new { x.FcntUp, x.CommTimestamp });
            //declare the current item
            dynamic currentItem = null;
            //declare the list of ranges
            List<dynamic> range = null;
            //loop through the sorted list
            foreach (var item in query)
            {
                //check if start of new range
                if (currentItem == null || item.Key.FcntUp < currentItem.Key.FcntUp)
                {
                    //create a new list if the FcntUp starts on a new range
                    range = new List<dynamic>();
                    //add the list to the parent list
                    arraylist.Add(range);
                }
                //add the item to the sublist
                range.Add(item);
                //set the current item
                currentItem = item;
            }
