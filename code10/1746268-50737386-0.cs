    public class EnemyFollow1 : MonoBehaviour
    {
        public string Name;
        public bool Boss;
        public int HP, MaxHP, Atk, MaxAtk, SpAtk, MaxSpAtk, Def, MaxDef, SpDef, MaxSpDef;
        public Sprite sprite;
        
        [SerializeField]
        private StatData statData;
    
        void Awake()
        {
            Name = statData.Name;
            Boss = StatData.Boss;
            // Etc...
        }
    }
