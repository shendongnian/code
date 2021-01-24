    [RequireComponent(typeof(Text))]
    public class ScoreText : MonoBehaviour
    {
        private Text scoreText;
    
        private void Awake()
        {
            scoreText = GetComponent<Text>();
            RegisterEvents();
        }
    
        private void OnDestroy()
        {
            UnregisterEvents();
        }
    
        private void RegisterEvents()
        {
            // Register the listener to the manager's event 
            ScoreManager.OnScoreChanged += HandleOnScoreChanged; 
        }
    
        private void UnregisterEvents()
        {
            // Unregister the listener
            ScoreManager.OnScoreChanged -= HandleOnScoreChanged;
        }
    
        private void HandleOnScoreChanged(int newScore)
        {
            scoreText.text = newScore.ToString();
        }
    }
