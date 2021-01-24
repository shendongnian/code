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
            ScoreManager.OnScoreChanged += HandleOnScoreChanged;
        }
    
        private void UnregisterEvents()
        {
            ScoreManager.OnScoreChanged -= HandleOnScoreChanged;
        }
    
        private void HandleOnScoreChanged(int newScore)
        {
            scoreText.text = newScore
        }
    }
