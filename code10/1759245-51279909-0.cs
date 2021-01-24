            public static IEnumerable<IBase> ConvertToList(int listType)
        {
            if (listType == 1)
            {
                var list = new List<ClassA>();
                ...
                return list;
            }
            if (listType == 2)
            {
                var list = new List<ClassB>();
                ...
                return list;
            }
            if (listType == 3)
            {
                var list = new List<ClassC>();
                ...
                return list;
            }
            return null;
        }
    }
    public class ClassA : IBase
    { }
    public class ClassB : IBase
    { }
    public class ClassC : IBase
    { }
    public interface IBase
    { }
