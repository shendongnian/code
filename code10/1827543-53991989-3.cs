    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI; // Required when Using UI elements.
    public class Example : MonoBehaviour
    {
        public Image drumstick;
        public void Start()
        {
            toggleDrumstick(); // This will toggle the drumstick. For example, if the drumstick is not being shown at the time, the drumstick will show on the screen. The opposite is true.
        }
    
        public void toggleDrumstick() {
            drumstick.enabled = !drumstick.enabled;
        }
    }
