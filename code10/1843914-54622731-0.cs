    class Program
    {
        static void Main(string[] args)
        {
            IEdmStrLst5 strLst = new EdmStrLstWrapper(new List<string>(new string[] { "A", "B", "C" }));
    
            var pos = strLst.GetHeadPosition();
            while (!pos.IsNull)
            {
                Console.WriteLine(strLst.GetNext(pos));
            }
        }
    }
    
    public class EdmStrLstWrapper : IEdmStrLst5
    {
        private readonly List<string> m_List;
    
        public EdmStrLstWrapper(List<string> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            m_List = list;
        }
    
        public int Count
        {
            get
            {
                return m_List.Count;
            }
        }
    
        public bool IsEmpty
        {
            get
            {
                return m_List.Count == 0;
            }
        }
    
        public void AddTail(string bsString)
        {
            m_List.Add(bsString);
        }
    
        public IEdmPos5 GetHeadPosition()
        {
            var pos = new EdmPosWrapper(m_List.GetEnumerator());
            pos.MoveNext();
    
            return pos;
        }
    
        public string GetNext(IEdmPos5 poPos)
        {
            if (poPos is EdmPosWrapper)
            {
                var val = (poPos as EdmPosWrapper).Current;
                (poPos as EdmPosWrapper).MoveNext();
                return val;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
    
    public class EdmPosWrapper : IEdmPos5
    {
        private readonly IEnumerator m_Enumerator;
    
        private bool m_IsLast;
    
        public EdmPosWrapper(IEnumerator enumerator)
        {
            m_Enumerator = enumerator;
        }
    
        public bool IsNull
        {
            get
            {
                return m_IsLast;
            }
        }
    
        public IEdmPos5 Clone()
        {
            return new EdmPosWrapper(m_Enumerator);
        }
    
        internal string Current
        {
            get
            {
                return m_Enumerator.Current as string;
            }
        }
    
        internal void MoveNext()
        {
            m_IsLast = !m_Enumerator.MoveNext();
        }
    }
