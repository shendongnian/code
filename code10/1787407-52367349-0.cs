    static T Analyze<T>(int limitValue, AbstractData abstractData) where T : AbstractData, new()
    {
        T t = new T();
        t.GivenValues = abstractData.GivenValues; //error : T is a type parameter which is not valid in the given context
        t.MaxValue= abstractData.GivenValues[0]; // same error
        foreach (var data in abstractData.GivenValues)
        {
           if (data<limitValue){
               t.MaxValue = data;
           }
        }
        return t; //same error
    }
