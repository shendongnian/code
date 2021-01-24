    using UnityEngine;
    using UnityEngine.UI;
    
    [RequireComponent(typeof(Dropdown))]
    [DisallowMultipleComponent]
    public class DropdownPlaceholder : MonoBehaviour
    {
        private Dropdown _dropdown;
        [SerializeField] private string _placeHolder;
    
        // Use this for initialization
        private void Start()
        {
            _dropdown = GetComponent<Dropdown>();
            _dropdown.captionText.text = _placeHolder;
        }
    }
