    Foo[] newArray = oldArray.Skip(3).Take(5).Select(item => item.Clone()).ToArray();
    
    class Foo
    {
        public Foo Clone()
        {
            return (Foo)MemberwiseClone();
        }
    }
