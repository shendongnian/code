    using UnityEngine;
    using System.Linq;
    using SimpleSQL;
    
        public class DriftSets
        {
        	[PrimaryKey, AutoIncrement]
        	public int DriftIndex { get; set; }
        	public string DriftID { get; set; }
        	public string DriftDateTime { get; set; }
        	public string DriftName { get; set; }
        	public string DriftStep { get; set; }
        	public float DriftLat { get; set; }
        	public float DriftLong { get; set; }
        	public string DriftTexLocation { get; set; }
        }
        
        public class SQLiteActions : MonoBehaviour
        {
        	public static SQLiteActions instance = null;
        	// reference to the database manager in the scene
        	public SimpleSQLManager DriftsDatabaseManager;
        
        	private string sql;
        
        	public void GetDriftTablesList()
        	{
        		sql =
        			"SELECT MIN(DriftIndex), DriftID, DriftName, DriftDateTime, DriftTexLocation  " +
        			"FROM Drift " +
        			"GROUP BY DriftID " +
        			"ORDER BY DriftDateTime DESC";
        
        		GameManager.driftSets = DriftsDatabaseManager.Query<DriftSets>(sql);
        
        		foreach (var driftSet in GameManager.driftSets)
        		{
        			Debug.Log(driftSet.DriftName);
        		}
        	}
         }
