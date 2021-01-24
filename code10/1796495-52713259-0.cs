        public async Task<List<ActivityModel>> GetActivitiesAsync(string domainName)
        {
            List<ActivityModel> activities = new List<ActivityModel>();
            CloudTable cloudTable = TableConnection("NodeEvents");
            string filter = TableQuery.GenerateFilterCondition("DomainName", QueryComparisons.Equal, domainName);
            TableContinuationToken continuationToken = null;
            do
            {
                var result = await cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<ActivityModel>().Where(filter), continuationToken);
                continuationToken = result.ContinuationToken;
                int index = 0;
                if (result.Results != null)
                {
                    foreach (ActivityModel entity in result.Results)
                    {
                        activities.Add(entity);
                        index++;
                        if (index == 500)
                            break;
                    }
                }
            } while (continuationToken != null);
            return activities;
        }
