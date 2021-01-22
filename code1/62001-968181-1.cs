    public abstract class Node
    {
        BaseAppObject _baseObject;
        //Empty constructor
        public Node() 
        {
            BaseAppObject = new BaseAppObject();
        }
        public Node(BaseAppObject baseObject, string name)
        {
            this.BaseObject = baseObject;
            this.Name = name;
        } 
        public string Name
        {
            get { 
                    string name = "";
                    _baseObject.GetUserString("CPName", ref name);
                    return name;             
                }
            set {
                    _baseObject.SetUserString("CPName", value);
                }
        }
    }
    public CustomClass:Node
    {
        // Empty constructor
        public CustomClass() : Base() {}
        public CustomClass(BaseAppObject baseObj,string name, string color):base(baseObj,name)
        public string Color
        {
            get { 
                    string name = "";
                    this.BaseObject.GetUserString("Color", ref name);
                    return name;             
                }
            set {
                    this.BaseObject.SetUserString("Color", value);
                }
        }
    }
