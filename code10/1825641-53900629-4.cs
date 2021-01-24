    class MyReader {
        public static T Read<T>(BinaryReader br) where T : IPopulateable, new(){
            T instance = new T();
            instance.Populate(br);
            return instance;
        }
    }
