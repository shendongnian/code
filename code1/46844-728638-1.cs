        public class Node
        {
            public virtual string GetIntrinsicProperty(String propertyKey)
            {
                switch(propertyKey)
                {
                    case "NodeUnderstoodProp":
                        return "I know! Call on me!";
                    default:
                        return null;
                }
            }
        }
        public class OtherNode : Node
        {
            public override string GetIntrinsicProperty(string propertyKey)
            {
                switch (propertyKey)
                {
                    case "OtherUnderstoodProp":
                        return "I'm the OtherNode, and I know better, call on me!";
                    default:
                        return base.GetIntrinsicProperty(propertyKey);
                }
            }
        }
        public class TestNode : Node
        {
        }
        static void Main(string[] args)
        {
            Node node = new OtherNode();
            var prop1 = node.GetIntrinsicProperty("NodeUnderstoodProp");
            var prop2 = node.GetIntrinsicProperty("OtherUnderstoodProp");
            var prop3 = node.GetIntrinsicProperty("PropTooHard!");
            node = new TestNode();
            prop1 = node.GetIntrinsicProperty("NodeUnderstoodProp");
            prop2 = node.GetIntrinsicProperty("OtherUnderstoodProp");
            prop3 = node.GetIntrinsicProperty("PropTooHard!");
        }
