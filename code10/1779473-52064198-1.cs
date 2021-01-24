    using System.Collections;
    
    public class Enemies : MonoBehaviour {
    
    	public float MaxHp;
    	public float Hp;
    
    	void Awake()
    	{
    		AssignStats();
    	}
    
    	public void AssignStats ()
    	{
    
    		if (gameObject.tag == "Enemy1")
    		{
    			MaxHp = 50;
    			Hp = MaxHp;
    			Debug.Log(Hp);
    		}
    
    		if (gameObject.tag== "Boss")
    		{
    
    			MaxHp = 500;
    			Hp = MaxHp;
    			Debug.Log(Hp);
    		}
    	}
    }
