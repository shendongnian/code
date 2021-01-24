    public override JSONNode this[string aKey]
    {
        get
        {
            if (m_Dict.ContainsKey(aKey))
                return m_Dict[aKey];
            else
                return new JSONLazyCreator(this, aKey);
        }
        set
        {
            //...
        }
    }
 
    public override JSONNode this[int aIndex]
    {
        get
        {
            if (aIndex < 0 || aIndex >= m_Dict.Count)
                return null;
            return m_Dict.ElementAt(aIndex).Value;
        }
        set
        {
            //...
        }
    }
