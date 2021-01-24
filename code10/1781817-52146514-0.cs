    public class StackOverflowScript : MonoBehaviour
    {
        public Detector CircleObject;
        public SquareItem SquarePrefab;
        public Vector2 SpawnOffset;
        List<SquareItem> _squares = new List<SquareItem>();
        private void Start()
        {
            InitGrid();
        }
        public void InitGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var pos = new Vector2(i, j) * SpawnOffset;
                    SquareItem square = Instantiate(SquarePrefab, pos, Quaternion.identity) as SquareItem;
                    square.Init(this, pos);
                    _squares.Add(square);
                }
            }
        }
        public void MoveCircle(SquareItem item, Vector2 newPos)
        {
            if (CircleObject.Squares.Contains(item))
                CircleObject.MoveTowardPos(newPos);
        }
    }
---------------------------
    public class SquareItem : MonoBehaviour
    {
        private StackOverflowScript _stackScript;
        public Vector2 Position
        {
            get; private set;
        }
        public void Init(StackOverflowScript script, Vector2 squarePosition)
        {
            _stackScript = script;
            Position = squarePosition;
        }
        private void OnMouseDown()
        {
            _stackScript.MoveCircle(this, this.transform.position);
        }
    }
