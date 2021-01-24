    public class A : Character
    {
    	public override void Accept(ICharacterVisitor visitor)
    	{
    		visitor.Visit(this);
    	}
    
    	public override void Attack(Character t)
    	{
    		var damage = 15;
    		t.Accept(new AttackVisitorA(damage));
    	}
    }
    
    public class B : Character
    {
    	public override void Accept(ICharacterVisitor visitor)
    	{
    		visitor.Visit(this);
    	}
    
    	public override void Attack(Character t)
    	{
    		throw new NotImplementedException();
    	}
    }
    
    public class C : Character
    {
    	public override void Accept(ICharacterVisitor visitor)
    	{
    		visitor.Visit(this);
    	}
    
    	public override void Attack(Character t)
    	{
    		throw new NotImplementedException();
    	}
    }
