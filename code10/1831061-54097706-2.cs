    public class Line : MonoBehaviour
    {
        public GameObject[] SaveArray;
        void Start()
        {
            SaveArray = GameObject.FindGameObjectsWithTag("BtnCharacter");
        }
    }
