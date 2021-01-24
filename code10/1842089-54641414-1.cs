    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/I18NData", order = 1)]
    public class I18NData : ScriptableObject
    {
        [SerializeField]
        private I18NSpriteData[] Sprites;
        public I18NSpriteData[] Sprites2 {
                get { return sprites; }
                set { sprites = value; }
        }
        [SerializeField]
        private I18NTextData[] Texts;
        public I18NTextData[] Texts2 {
                get { return texts; }
                set { texts= value; }
        }
    }
