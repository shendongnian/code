    [RequiresComponent(typeof(Text))]
    public sealed class EnterableText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private static readonly Vector3 hoveredPosition = new Vector3(100f, 100f, 0f);
        public string defaultText;
        public string hoveredText;
        private Vector3 initialPosition;
        private Text textComponent;
        private void Awake()
        {
            initialPosition    = transform.position;
            textComponent      = GetComponent<Text>();
            textComponent.text = defaultText;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.position = new Vector3(100f, 100f, 0f);
            textComponent.text = hoveredText;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.position = initialPosition;
            textComponent.text = defaultText;
        }
    }
