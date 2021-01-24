    public class Spawner : MonoBehaviour {
    
      public Transform SpawnPrefab;
      public Vector3 Scale;
    
        void Start () {
          var spawn = Instantiate(SpawnPrefab, Vector3.zero, Quaternion.identity);
          spawn.localScale = Vector3.Scale(spawn.localScale, Scale);
          Physics.SyncTransforms();
          spawn.GetComponent<Rigidbody>().ResetCenterOfMass();
        }
    }
