    static public class ObjectManager<T>
    {
        ... the code that already exists in ObjectManager ...
        
        static public U GetById<U>(long id)
        {
            object obj = GetById(id);
            if (obj is U)
                return (U)obj;
            return default(U);
        }
    }
