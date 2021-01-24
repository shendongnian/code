            if (CurrentFilter !=null && CurrentFilter .Count()>0)
            {
                //Logic if CurrentFilter exists as normal
            }
            else
            {
               List<string> SearchList = new List<string>();
                foreach (var key in HttpContext.Request.Query)
                {
                    if (key.Key.Contains("SearchString"))
                    {
                        SearchList.Add(key.Value);
                        string IndividualTag = key.Value;
                    }
                    //Same logic as above
                }
                CurrentFilter = SearchList.ToArray();
            }
