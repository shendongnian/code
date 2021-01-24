    public class Example : MonoBehaviour
    {
        // Toggles the time scale between 1 (normal) and 0.5 (twice as fast)
        // whenever the user hits the Fire1 button.
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.timeScale == 1.0f)
                {
                    Time.timeScale = 0.5f;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }
                // Also adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 frames per real-time second
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }
    }
