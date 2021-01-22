        public class Node
        {
            public string GetIntrinsicProperty(String propertyKey)
            {
                //sets the original type value
                Type currType = this.GetType();
                Node thisNode = this;
                String propertyValue;
                while (currType.IsSubclassOf(typeof(Node)))
                {
                    MethodInfo mi = currType.GetMethod("GetIntrinsicProperty",BindingFlags.Instance | BindingFlags.Public,null,new Type[] {typeof(string)},null);
                    if (mi.DeclaringType != typeof(Node))
                    {
                        propertyValue = (string)mi.Invoke(this, new object[] { propertyKey });
                        if (propertyValue != null)
                        {
                            return propertyValue;
                        }
                    }
                    //sets CurrType to its base type
                    currType = currType.BaseType;
                }
                return null;
            }
        }
        public class OtherNode : Node
        {
            new public string GetIntrinsicProperty(string propertyKey)
            {
                return "OtherNode says Hi!";
            }
        }
        public class TestNode : Node
        {
        }
