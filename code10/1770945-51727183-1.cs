    public class UIController : MonoBehaviour
    {
        public List<RelevantClassName> contentToDisplay;
        [Header("References"]
        public Transform buttonParent;
        public Transform contentParent;
        public GameObject buttonPrefab;
        public GameObject contentPrefab;
        
        public void DisplayUI()
        {
            foreach(RelevantClassName content in contentToDisplay)
            {
                content.contentHolder = Instantiate(contentPrefab, contentParent);
                content.button = Instantiate(buttonPrefab, buttonParent);
                // And here you can run any custom changes, for example finding a text
                // component on the content holder and changing the description:
                content.contentHolder.GetComponent<Text>().text = content.text;
            }
        }
