    [CreateAssetMenu(menuName = "Units/Monster")]
    public class Monster : ScriptableObject
    {
        public int Id;
        public string Name;    
        [TextArea(2, 5)]
        [SerializeField]
        protected string BaseDescription;
        public Sprite UiButtonSprite;
        public float Attack;
        public float Health;
        
        public int Armor;
        // etc.
     }
