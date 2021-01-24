    public static class MyComplexObjectReader{
        public static MyComplexObject ReadComplexObject(this BinaryReader br){
            var o = new MyComplexObject();
            o.Field1 = br.ReadString();
            return o;
        }
    }
