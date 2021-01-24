    // Collision functions based on correct layering (Player/LightingZones)
    [RequireComponent(typeof(Collider))]
    public class LightingCalculator : MonoBehaviour
    {
        private bool _entered = false;
        private void Update()
        {
            if (_entered) FindObjectOfType<PlayerController>().LightingValue = CalculateLighting();
        }
        private void OnCollisionEnter(Collision col)
        {
            _entered = true;
        }
        private void OnCollisionExit(Collision col)
        {
            _entered = false;
        }
        private float CalculateLighting()
        {
            float lighting = 0;
            // Your calculation
            return lighting;
        }
    }
