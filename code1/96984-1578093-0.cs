      //why bother?
    //public class ChildEntityCollection : ICollection<ChildEntity>{}
    public class ParentEntity
    {
       //choose one
      private ChildEntity[] children;
      private List<ChildEntity> childrenInList;
      private HashSet<ChildEntity> childrenInHashSet;
      private Dictionary<int, ChildEntity> childrenInDictionary;
       // or if you want to make your own, make it generic
      private Balloon<ChildEntity> childrenInBalloon;
    }
    public class ChildEntity
    {
    }
