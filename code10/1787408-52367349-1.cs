    static void Analyze<T>(int limitValue, AbstractData abstractData, T t) where T : AbstractData
    {
        t.GivenValues = abstractData.GivenValues; //error : T is a type parameter which is not valid in the given context
        t.MaxValue= abstractData.GivenValues[0]; // same error
        foreach (var data in abstractData.GivenValues)
        {
           if (data<limitValue){
               t.MaxValue = data;
           }
        }
    }
