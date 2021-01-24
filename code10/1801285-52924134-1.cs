    using UnityEngine;
    using UnityEngine.UI;
    
    [RequireComponent(typeof(Button))]
    [DisallowMultipleComponent]
    public class HintsController : MonoBehaviour
    {
        private Image _image;
        private Text _text;
        private float _originalAlpha;
    
        // optional to controll if Hints should be enabled on starting the App
        pubic bool enableAtStart;
        private void Awake()
        {
            // GetComponentInChildren finds the component on this object or any
            // child of this object recursively
            // (true) : make sure you also find the components if this or the child objects
            // are currently disabled
            // on this way you don't even have to rely on that the Image is on the 
            // Button GameObject or below in the hierachy
            _image = GetComponentInChildren<Image>(true);
            _text = GetComponentInChildren<Text>(true);
            if(_image)
            {
                _originalAlpha = _image.color.a;
            }
            // optional to controll if Hints should be enabled on starting the App
            ShowHints(enableAtStart);
        }
    
        public void ShowHints(bool isVisible)
        {
            // Skip if no Image found
            if (_image)
            {
                 var color = _image.color;
                 color.a = isVisible ? _originalAlpha : 0;
                 _image.color = color;
            }
    
            // Skip if no Text found
            if (_text)
            {
                _text.enabled = isVisible;
            }
        }
    }
