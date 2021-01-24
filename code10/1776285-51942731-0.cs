    public class BattleManager : MonoBehaviour
    {
    
        public Enemy debugEnemy;
    
        IEnumerator Start()
        {
            //get a reference to the DBAccess
            DBAccess DBA = GameObject.Find("ManagerDB").GetComponent<DBAccess>();
            yield return StartCoroutine(DBA.GetEnemy(1, (result) => { debugEnemy = result; }));
    
            //YOU CAN NOW USE debugEnemy below
    
        }
    }
