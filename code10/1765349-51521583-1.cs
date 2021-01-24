    // The class name "anser" was misspelled. Also you typically use PascalCase for class names.
    public class Answer : MonoBehaviour
    {
        private string secretWord = "eje";
    
        public void GetInput(string guessWord) 
        {
            if (secretWord == guessWord.ToLower()) 
            {
                SceneManager.LoadScene("Question2");
                return; // eliminates the need for an else clause
            } 
    
            SceneManager.LoadScene("Front Page");
        }
    }
