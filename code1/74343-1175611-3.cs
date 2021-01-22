    public class SomeBaseTypeForAllYourEntities
    {
        public int Id { get; set; }
    }
    sealed public class Entity1 : SomeBaseTypeForAllYourEntities
    {
        ... other properties, etc. ...
    }
