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
