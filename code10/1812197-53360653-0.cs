      public class Creator
            {
                public static T CreateHuman<T>()
                    where T : Human, new()
                {
                    return new T();
                }
    
                public static T CreateAnimal<T>()
                    where T : Animal, new()
                {
                    return new T();
                }
    
                public static T Create<T>()
                    where T : class, new()
                {
    
                    switch (typeof(T))
                    {
                        case Type t when t == typeof(Human):
                            //throw new Exception("Type can be only Animal");
                            break;
                        case Type t when t == typeof(Animal):
                            //throw new Exception("Type can be only Human");
                            break;
    
                    }
    
                    return default(T);
                }
            }
        }
