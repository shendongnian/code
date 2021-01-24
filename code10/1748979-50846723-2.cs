    public class AttackVisitorA : ICharacterVisitor
    {
    	int _baseDamage;
    	public AttackVisitorA(int baseDamage){
    		_baseDamage = baseDamage;
    	}
    	public void Visit(A a)
    	{
    		// A does normal damage to A.
    		a.HP -= _baseDamage;
    	}
    
    	public void Visit(B b)
    	{
    		// A does double damage to B.
    		b.HP -= (_baseDamage * 2);
    	}
    
    	public void Visit(C c)
    	{
    		// A does half damage to C.
    		c.HP -= (_baseDamage / 2);
    	}
    }
