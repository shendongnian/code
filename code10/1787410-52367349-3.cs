    static void Analyze<T>(int limitValue, AbstractData abstractData, T t) where T : AbstractData
    {
        t.GivenValues = abstractData.GivenValues;
        t.MaxValue= abstractData.GivenValues[0];
        foreach (var data in abstractData.GivenValues)
        {
           if (data<limitValue){
               t.MaxValue = data;
           }
        }
    }
