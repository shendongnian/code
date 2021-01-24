    public class Line : MonoBehaviour
    {
        public List<GameObject> SaveList;
        void Start()
        {
            SaveList = new List<GameObject>(GameObject.FindGameObjectsWithTag("BtnCharacter"));
        }
    }
