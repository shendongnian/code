    public class BattleManager : Monobehaviour{
    
     public Enemy debugEnemy;
    
     void Start()
     {
       //get a reference to the DBAccess
       DBA = GameObject.Find("ManagerDB").GetComponent<DBAccess>();
    
       debugEnemy = DBA.GetEnemy(1,(e)=>{
          if(e!=null)
          {
          //Do something with enemy here, it will be couple frames later
          }
       });
     }
    }
