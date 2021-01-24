    static T Analyze<T>(int limitValue, AbstractData abstractData) where T : AbstractData, new()
    {
        T t = new T();
        t.GivenValues = abstractData.GivenValues;
        t.MaxValue= abstractData.GivenValues[0];
        foreach (var data in abstractData.GivenValues)
        {
           if (data<limitValue){
               t.MaxValue = data;
           }
        }
        return t;
    }
