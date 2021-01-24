    public class MyEnumerator : IEnumerator
    {
        private string First => nameof(First);
        private string Second => nameof(Second);
        private string Third => nameof(Third);
        private int counter = 0;
    
        public object Current { get; private set; }
    
        public bool MoveNext()
        {
            if (counter > 2) return false;
    
            counter++;
            switch (counter)
            {
                case 1:
                    Current = First;
                    break;
                case 2:
                    Current = Second;
                    break;
                case 3:
                    Current = Third;
                    break;                    
            }
            return true;
        }
    
        public void Reset()
        {
            counter = 0;
        }
    }
