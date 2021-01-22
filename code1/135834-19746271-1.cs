    class PersonLogic
    {
        public bool Add(PersonEntity aPersonEntity, ushort age = 12, String id = "1", String name = "Roy")
        {
            string log =  new ParamaterLogModifiedUtility(() => aPersonEntity, () => age, () => id, () => name).GetLog();
            return true;
        }
    }
