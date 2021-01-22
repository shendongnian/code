    class Parser
    {
        public ObjectType1 action(ObjectType1 objectType1)
        {
            Console.WriteLine("1");
            return objectType1;
        }
        public ObjectType2 action(ObjectType2 objectType2)
        {
            Console.WriteLine("2");
            return objectType2;
        }
    }
    class ObjectType1 { }
    struct ObjectType2 { }
