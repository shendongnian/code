        public static bool isObjOfType(Object OBJ, Type Type)
        {
            return OBJ.GetType().Name == Type.Name;
        }
        public static bool isObjOfType(Object OBJ, string Type)
        {
            return OBJ.GetType().Name == Type;
        }
