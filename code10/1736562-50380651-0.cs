    public abstract class BaseClass<T> where T : BaseClass<T>
    {
        
        public string Id {get; set;}
        public string OtherProperty {get; set;}
        public T WorkWithTAndReturn(T instanceOfASubClass)
        {
            //you can access base properties like
            var theId = T.Id;
            T.OtherProperty = "Look what I can do";
            return T
        }
        public T Clone()
        {
            var newT = DoCloneStuff(instanceToClone);//do clone stuff here
            return newT;
        }
        public static T Clone(T instanceToClone)
        {
            return (T)instanceToClone.MemberwiseClone();
        }
    }
