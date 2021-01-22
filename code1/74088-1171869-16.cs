    sealed class MyValueObject : ValueObject<MyValueObject> {
        public DayOfWeek day;
        public string NamedPart;
        //properties work fine too
    }
  
