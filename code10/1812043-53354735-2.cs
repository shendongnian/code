    public class ScoreSys : MonoBehaviour
    {
    
        public Text TextCount;
        private int _Count;
    
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                if (_Count != value)
                {
                    _Count = value;
                    TextCount.text = _Count.ToString();
                }
            }
        }
    
        void Start()
        {
            Count = 82;
            TextCount.text = _Count.ToString();
        }
    }
