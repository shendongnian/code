    public abstract class Node : BaseAppObject
    {
    
        public Node(string name) : base()
        {            
            this.Name = name;
        } 
    
        public string Name
        {
            get { 
                    string name = "";
                    this.GetUserString("CPName", ref name);
                    return name;             
                }
    
            set {
                    this.SetUserString("CPName", value);
                }
        }
    }
