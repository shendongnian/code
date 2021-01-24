    public class A : ScriptableObject
    {
        [SerializeField]
        public string team;
        public Action RaiseChangeName;
        private void OnValidate()
        {
            Debug.Log($"My team name has been changed to {team}.");
            if(RaiseChangeName != null) { RaiseChangeName(); }
        }
    }
    
    public class B : ScriptableObject
    {
        [SerializeField]
        public A a;
        void Awake()
        {
             a.RaiseChangeName += OnATeamChanged;
        }
    
        // How can I detect changes to A and call this functions?
        private void OnATeamChanged()
        {
            Debug.Log($"A's team name has been changed to {a.team}.");
        }
    }
