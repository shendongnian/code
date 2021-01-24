    public class Timer : MonoBehaviour
    {
        int timeLeft;
        void Start()
        {
            instruction = GetComponent<Text>();
            InvokeRepeating("time", 0, 1);
    
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                timeLeft = 120;
            }
            else
            {
                timeLeft = 90;
            }
    /*
            timeLeft = (SceneManager.GetActiveScene().buildIndex == 7) ? 120 : 90;
    */
        }
    }
