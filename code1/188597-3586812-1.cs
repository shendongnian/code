        public static object OBJRet(Type vClasseType, ArrayList tArray, int vIndex)
        {
            return typeof(cFunctions).GetMethod("ObjectReturner").MakeGenericMethod(vClasseType).Invoke(null, new object[] { tArray, vIndex });
        }
        public static object ObjectReturner<T>(ArrayList tArray, int vIndex) where T : new()
        {
            return tArray[vIndex];
        }
