    // Domain classes
    public class Animal : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Unwanted { get; set; }
    }
    public class Cat : Animal
    {
        public virtual int WhiskerLength { get; set; }
        public virtual int ClawCount { get; set; }
    }
    public class Dog : Animal
    {
        public virtual int TailWagRate { get; set; }
    }
    public class Boxer : Dog
    {
        public string DroolBucket { get; set; }
    }
    public class AnimalMapJoinedSubclassOverride : IAutoMappingOverride<Animal>
    {
        public void Override(AutoMap<Animal> mapping) {
            mapping.Map(x => x.Name);
            mapping.IgnoreProperty(x => x.Unwanted);
            mapping.JoinedSubClass("CatId", CatMap.AsJoinedSubClass());
            mapping.JoinedSubClass("DogId", DogMap.AsJoinedSubClass());
            //mapping.DiscriminateSubClassesOnColumn("Type")
            //    .SubClass<Cat>("CatId", CatMap.AsSubClass())
            //    .SubClass<Dog>("CatId", DogMap.AsSubClass());
        }
    }
    public class CatMap
    {
        public static Action<JoinedSubClassPart<Cat>> AsJoinedSubClass()
        {
            return part =>
            {
                part.Map(x => x.ClawCount).Not.Nullable();
                part.Map(x => x.WhiskerLength).Not.Nullable();
            };
        }
        public static Action<SubClassPart<Cat>> AsSubClass()
        {
            return part =>
            {
                part.Map(x => x.ClawCount);
                part.Map(x => x.WhiskerLength);
            };
        }
    }
    public class DogMap
    {
        public static Action<JoinedSubClassPart<Dog>> AsJoinedSubClass()
        {
            return sub =>
            {
                sub.Map(x => x.TailWagRate).Not.Nullable();
            };
        }
        public static Action<SubClassPart<Dog>> AsSubClass()
        {
            return sub =>
            {
                sub.Map(x => x.TailWagRate);
            };
        }
    }
    public class BoxerMap
    {
        public static Action<JoinedSubClassPart<Boxer>> AsJoinedSubClass()
        {
            return sub =>
            {
                sub.Map(x => x.DroolBucket);
            };
        }
        public static Action<SubClassPart<Boxer>> AsSubClass()
        {
            return sub =>
            {
                sub.Map(x => x.DroolBucket);
            };
        }
    }
