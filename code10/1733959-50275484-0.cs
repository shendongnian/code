    public class LevelControlScript2 : MonoBehaviour
    {
        // Get references to game objects that should be disabled and enabled
        // at the start
        GameObject[] toEnable, toDisable;
    
        // References to game objects that should be enabled
        // when correct or incorrect answer is given
        private int triesLeft = 2;    // Set this to 1 (leave after second) or whatever when a level starts
        public GameObject correctSign, incorrectSign, incorrectSign2;
    
        public AudioSource _audioSource;
    
        public AudioClip _incorrect;
        public AudioClip _correct;
    
        // Variable to contain current scene build index
        int currentSceneIndex;
    
        // Use this for initialization
        void Start()
        {
    
            // Getting current scene build index
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    
            // Finding game objects with tags "ToEnable" and "ToDisable"
            toEnable = GameObject.FindGameObjectsWithTag("ToEnable");
            toDisable = GameObject.FindGameObjectsWithTag("ToDisable");
    
            // Disabling game objects with tag "ToEnable"
            foreach (GameObject element in toEnable)
            {
                element.gameObject.SetActive(false);
            }
    
        }
    
        // Method is invoked when correct answer is given
        public void RightAnswer()
        {
            // Disabling game objects that are no longer needed
            foreach (GameObject element in toDisable)
            {
                element.gameObject.SetActive(false);
            }
    
            // Turn on "correct" sign
            correctSign.gameObject.SetActive(true);
            _audioSource.clip = _correct;
            _audioSource.Play();
    
    
            // Invoke GotoMainMenu method in 1 second
            Invoke("LoadNextLevel", 1f);
            
        }
    
    
        // Method is invoked if incorrect answer is given
        public void WrongAnswer()
        {
            // Disabling game objects that are no longer needed
            foreach (GameObject element in toDisable)
            {
                element.gameObject.SetActive(false);
            }
    
            // Turn on "incorrect" sign
            incorrectSign.SetActive(true);
    
            // Disabling game objects that are no longer needed
            foreach (GameObject element in toDisable)
            {
                element.gameObject.SetActive(true);
    
            }
    
            triesLeft--;
            if (triesLeft <= 0)
            {
                // Disabling game objects that are no longer needed
                foreach (GameObject element in toDisable)
                {
                    element.gameObject.SetActive(false);
                }
                // Turn on "incorrect" sign
                incorrectSign2.SetActive(true);
                _audioSource.clip = _incorrect;
                _audioSource.Play();
    
                // Invoke GotoMainMenu method in 1 second
                Invoke("GotoCategories", 1f);
            }
        }
    
    
        // Method loads next level depending on current scenes build index
        void LoadNextLevel()
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    
        // Method loads Category scene
        void GotoCategories()
        {
            SceneManager.LoadScene("Easy");
        }
    }
