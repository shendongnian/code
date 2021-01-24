    public class Parent : IParent
    {
        public virtual string Suffix => "World";
        public String World => "Hello " + Suffix;
            }
        }
    }
    public class Children : Parent
    {
        public override string Suffix => "Again";
    }
