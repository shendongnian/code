    public class LeafA : Group {
    	public override void Accept(GroupVisitor visitor){
    		visitor.Visit(this);
    	}
    }
    public class GroupB : Group
    {
    	public List<Group> Groups {get;set;}
    	public override void Accept(GroupVisitor visitor) {
    		visitor.Visit(this);
    	}
    }
