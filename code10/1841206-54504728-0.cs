    public class FlowVisitor {
        
        public void Visit(IFlow flow) {
            Visit((dynamic) flow);
        }
    
        // Specific visit methods (private)...
    }
