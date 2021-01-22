    public enum myEnum { Alpha, Beta }
    
    public class Foo
    {
        private myEnum yourEnum = myEnum.Alpha;
        public myEnum getMyEnum
        { 
            get { return yourEnum; } 
        }
    }
