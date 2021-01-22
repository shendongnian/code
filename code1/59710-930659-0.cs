    public static class MyUtiltiyClass {
        private static readonly bool exclamationIsSet;
        public static bool ExclamationIsSet {get{return exclamationIsSet;}}
        static MyUtiltiyClass() {
            exclamationIsSet = FindWhetherTheFlagIsSet();
        }
        public static void WriteWithMarker(this TextWriter writer, SomeType value) {
            writer.Write(value);
            if(ExclamationIsSet) writer.Write(SomeExtraStuff);
        }
        //etc
    }
