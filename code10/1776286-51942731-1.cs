    public class DBAccess : MonoBehaviour
    {
        public IEnumerator GetEnemy(int EnemyID, Action<Enemy> enemyResult)
        {
            yield return StartCoroutine(GetEnemyFromDB(EnemyID, enemyResult));
        }
        private IEnumerator GetEnemyFromDB(int EnemyID, Action<Enemy> enemyResult)
        {
            WWWForm postData = new WWWForm();
            postData.AddField("EnemyID", EnemyID);
            WWW dbProc = new WWW(GetEnemyURL, postData);
            yield return dbProc;
            if (string.IsNullOrEmpty(dbProc.error)) //error is null or empty so: SUCCESS!
            {
                string jsonstring = "{\"Items\":" + dbProc.text + "}";
                Enemy[] EnemiesFromDB;
                EnemiesFromDB = JsonHelper.FromJson<Enemy>(jsonstring);
                if (EnemiesFromDB.Length > 0)
                {
                    //Pass result back to param
                    if (enemyResult != null)
                        enemyResult(EnemiesFromDB[0]);
                    //HERE enemy.EnemyID is 1 and enemy.Name is "Evil Enemy Monster Man!"
                    //So it is working here!
                }
                else throw new System.Exception("No Enemy Found When Reading Json: " + JsonUtility.FromJson<Enemy>(jsonstring));
            }
            else throw new System.Exception("DB ERROR: " + dbProc.error);
        }
    }
