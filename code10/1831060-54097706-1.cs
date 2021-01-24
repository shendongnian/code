    public class Line : MonoBehaviour
    {
        public List<Vector3> SaveList;//use List<Transform> to create transform list
        void Start()
        {
            SaveList = new List<Vector3>();
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("BtnCharacter");
            foreach(GameObject GO in objectsWithTag){
                SaveList.Add(GO.transform.position);//use GO.transform to add the transform in the list
            }
        }
    }
