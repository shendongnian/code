    public class YourClass : MonoBehaviour
    {
        private float cooldownTime;
        private bool isCooldown;
        // your code
        private void Update()
        {
            if (!isCooldown)
            {
                // Do stuff
            }
        }
        private IEnumerator Cooldown()
        {
            // Start cooldown
            isCooldown = true;
            // Wait for time you want
            yield return new WaitForSeconds(cooldownTime);
            // Stop cooldown
            isCooldown = false;
        }
    }
