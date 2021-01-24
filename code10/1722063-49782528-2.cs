    public class GroupVisitor {
    	private Group _parent;
        public GroupVisitor(Group parent) {
    		_parent = parent;
    	}
    
    	public void Visit(LeafA leaf) {
    		leaf.ParentGroup = _parent;
    	}
    	
    	public void Visit(GroupB group) {
    		group.ParentGroup = _parent;
    		var visitor = new GroupVisitor(group);
    		foreach (var item in group.Groups)
    			item.Accept(visitor);
    		
    	}
    }
