    using UnityEngine;
    using UnityEngine.UI;
    
    public class TextChangeScript : MonoBehaviour
    {
        public Text m_MyText;
        public Text OtherText;
        IEnumerator StoryText() {
            m_MyText.text = "There was once a mother and her child";
            yield return new WaitForSeconds (3);
            m_MyText.text = "The mother loved her child very dearly";
            yield return new WaitForSeconds (3);
            m_MyText.text = "Then one day blah blah blah";
        }
        void Start()
        {
            StartCoroutine(StoryText());
        }
    
        void Update()
        {
    
        }
    }
