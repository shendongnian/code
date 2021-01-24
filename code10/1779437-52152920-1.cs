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
            // add the placeholder option
            _dropdown.options.Insert(0, new Dropdown.OptionData(_placeHolder));
            // after adding an option Dropdown adjusts the value so
            // we have to set it to the new option
            _dropdown.value = 0;
            // Dropdown still wouldn't adopt the label -> set the label
            _dropdown.captionText.text = _placeHolder;
        }
    }
