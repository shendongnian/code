    IEnumerable<DynamicObj> GetDynamicObjects(IEnumerable<BaseObj> baseList)
    {
        foreach(BaseObj baseObj in baseList)
            if(baseObj is DynamicObj)
                yield return (DynamicObj)baseObj;
    }
    
    List<DynamicObj> dynamicList = new List<DynamicObj>(GetDynamicObjects(...));
