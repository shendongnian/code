    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/I18NData", order = 1)]
    public class I18NData : ScriptableObject
    {
        [SerializeField]
        private I18NSpriteData[] Sprites;
        public I18NSpriteData[] Sprites2 {
                get { return Sprites; }
                set { Sprites = value; }
        }
        [SerializeField]
        private I18NTextData[] Texts;
        public I18NTextData[] Texts2 {
                get { return Texts; }
                set { Texts= value; }
        }
    }
