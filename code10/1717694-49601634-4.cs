    var results = new List<ReturnType>();
            foreach (var a in result)
            {
                foreach (var date in a.AppDates)
                {
                    var returnType = new ReturnType
                    {
                        ID = a.ID,
                        AppDate = date
                    };
                    results.Add(returnType);
                }
            }
