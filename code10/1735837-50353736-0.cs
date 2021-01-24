    List<ResortDealResultsObject> resultList = new List<ResortDealResultsObject>();
                foreach (var row in resultsObj)
                {
                        var tempVm = new ResortDealResultsObject
                        {
                            Name = row.Name,
                            ImageUrl = row.ImageUrl,
                            ResortDetails = row.ResortDetails,
                            CheckIn = row.CheckIn,
                            Address = row.Address,
                            TotalPrice = row.TotalPrice
                        };
                        resultList.Add(tempVm);
                }
