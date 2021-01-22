    public Cat this[string name]{
        get{
            //Will return the first Cat in the list (or null if none is found)
            return m_List.Where(c => c.Name == name).FirstOrDefault();
        }
    }
