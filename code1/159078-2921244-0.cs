    public Dictionary<DateTime, object> GetAttributeList(
                EnumFactorType attributeType
                ,Thomson.Financial.Vestek.Util.DateRange dateRange)
            {
                DateTime startDate = dateRange.StartDate;
                DateTime endDate = dateRange.EndDate;
                return (
                    //Step 1: Iterate over the attribute list and filter the records by 
                    // the supplied attribute type 
                  from assetAttribute in AttributeCollection
                  where assetAttribute.AttributeType.Equals(attributeType)
                  //Step2:Assign the TimeSeriesData collection into a temporary variable  
                  let timeSeriesList = assetAttribute.TimeSeriesData
                  //Step 3: Iterate over the TimeSeriesData list and filter the records by 
                  // the supplied date  
                  from timeSeries in timeSeriesList.ToList()
                  where timeSeries.Key >= startDate && timeSeries.Key <= endDate
                  select new { timeSeries.Key, timeSeries.Value })
                  .ToDictionary(x => x.Key, x => x.Value);                 
                   
            }
