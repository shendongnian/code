    [InheritedExport]
    public abstract class BTool {
    }
    
    public class HandTool : BTool {
    }
    
    public class LassoTool : BTool {
    }
    
    public class Game {
    
        [ImportMany]
        public List<BTool> Tools {
            get;
            set;
        }
    
    }
