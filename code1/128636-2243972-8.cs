    public enum RestrictionLevel
    {
        Low,
        Medium,
        Grounded
    }
    public class Person
    {
        public RestrictionLevel RestrictionLevel { get; private set; }
        protected static void SetRestrictionLevelInternal(Person person, RestrictionLevel restrictionLevel)
        {
            person.RestrictionLevel = restrictionLevel;
        }
    }
    public class Child : Person { }
    public class Parent : Person
    {
        public void SetRestrictionLevel(Child child, RestrictionLevel restrictionLevel)
        {
            SetRestrictionLevelInternal(child, restrictionLevel);
        }
    }
