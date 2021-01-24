    using UnityEngine;
    
    public class OpacityController : MonoBehaviour
    {
        public float opacity = 0.5f; //opacity control
        public Component[] renderers; //get all the children renderer component
    
        private bool toggle = false;
    
        private void Start()
        {
            renderers = GetComponentsInChildren<Renderer>();
        }
    
        public void OnOpacityButton()
        {
            // invert the toggle value
            toggle = !toggle;
    
            // select the opacity value using the trinary operator
            float newOpacity = toggle ? opacity : 1f;
    
            // assign the new opacity to all the renderers
            foreach (Renderer renderer in renderers)
            {
                // copy the current color and assign a new opacity to it.
                Color newColor = renderer.material.color; 
                newColor.a = newOpacity;
    
                // assign the new color to material rather than sharedmaterial to change only the current material
                renderer.material.color = newColor; 
            }
        }
    }
