    public void GetEnemy(int EnemyID, Action<Enemy> callback)
    {
        StartCoroutine(GetEnemyFromDB(EnemyID,callback));
    }
    
    private IEnumerator GetEnemyFromDB(int EnemyID, Action<Enemy> callback)
    {
        WWWForm postData = new WWWForm();
        postData.AddField("EnemyID", EnemyID);
    
        WWW dbProc = new WWW(GetEnemyURL, postData);
        yield return dbProc; //code below is executed later, after after receiving the response from the server
    
        if (string.IsNullOrEmpty(dbProc.error)) //error is null or empty so: SUCCESS!
        {
            string jsonstring = "{\"Items\":" + dbProc.text + "}";
            Enemy[] EnemiesFromDB;
            EnemiesFromDB = JsonHelper.FromJson<Enemy>(jsonstring);
            if (EnemiesFromDB.Length > 0)
            {
                var enemy = EnemiesFromDB[0];
                callback(enemy); //return enemy
                yield break;
            }
    		else
    			Debug.LogError("Enemy does not exist");
        }
    	else
    		Debug.LogError("WWW request failed: " + dbProc.error);
    	callback(null); //call empty calbback to inform that something has failed
     } 
