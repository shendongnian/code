    public class GenerateEnv1 : MonoBehaviour
    {
        public GameObject[] EnvTile;
        float tileZ = 29.31f;
        // Use this for initialization
        void Start()
        {
            Instantiate(EnvTile[Random.Range(0, 4)], new Vector3(0f, 0f, tileZ), Quaternion.EulerAngles(0, 0, 0));
            Instantiate(EnvTile[Random.Range(0, 4)], new Vector3(0f, 0f, tileZ * 2), Quaternion.EulerAngles(0, 0, 0));
        }
        void OnCollisionExit(Collision col)
        {
            if (col.gameObject.tag == "ground")
            {
                col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x , col.gameObject.transform.position.y, col.gameObject.transform.position.z + (tileZ * 2));
            }
        }
    }
