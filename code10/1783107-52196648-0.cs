    public interface IEvilutionChecker{
    	
    	bool AllowEvolution();
    }
    
    
    public class EvolutionCheckerA : IEvilutionChecker{
    	private ILevellable levelEvolvable;
    	public EvolutionCheckerA(ILevellable levelEvolvable){
    		this.levelEvolvable = levelEvolvable;
    	}
    	public bool AllowEvolution(){
    		return levelEvolvable.Level > 10;
    	}
    }
    
    public class EvolutionCheckerB : IEvilutionChecker{
    	private IEvolvable evolvable;
    	public EvolutionCheckerB(IEvolvable evolvable){
    		this.evolvable = evolvable;
    	}
    	public bool AllowEvolution(){
    		return someCondition;
    	}
    }
    
    public class EvolutionHandler2
    {
    	public IEvolvable evolvable; 
    	public IEvilutionChecker EvolutionChecker {get;set;};
    
    	public void TryEvolveCharacter
    	{
    		if(EvolutionChecker.AllowEvolution())  
    		{
    			evolvable.IncreaseEvolution(1);
    		}
    	}
    }
