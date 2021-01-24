    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/I18NData", order = 1)]
    public class I18NData : ScriptableObject
    {
        
        [FormerlySerializedAs("Sprites")]
        public I18NSpriteData[] Sprites2;
        public I18NTextData[] Texts;
    }
