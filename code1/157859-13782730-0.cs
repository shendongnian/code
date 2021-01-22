    public class NQueensSolver
    {
        private readonly List<int[]> _solutions = new List<int[]>();
        private readonly int[] _current;
        public int N { get; private set; }
        public NQueensSolver(int n)
        {
            N = n;
            _current = new int[N];
        }
        public IList<int[]> FindAllFormations()
        {
            PopulateFormations(0);
            return _solutions;
        }
        private void PopulateFormations(int row)
        {
            if (row == N)
            {
                _solutions.Add(_current.ToArray());
                return;
            }
            for (int col = 0; col <= N-1; col++)
            {
                if (Threatened(row, col))
                    continue;
                _current[row] = col;
                PopulateFormations(row + 1);
            }
        }
        private bool Threatened(int row, int col)
        {
            for (int i = 0; i <= row - 1; i++)
                if (_current[i] == col || row - i == Math.Abs(col - _current[i]))
                    return true;
            
            return false;
        }
    }
