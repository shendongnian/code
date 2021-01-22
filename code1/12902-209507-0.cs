    public class LessThanRule : Rule
    {
        private bool m_Result = false;
        private object m_ObjectToCompare = null;
        private object m_ObjectToEvaluate = null;
    
        public bool Result
        {
            get { return this.m_Result; }
        }
    
        public object ObjectToCompare
        {
            get { return this.m_ObjectToCompare; }
            set { this.m_ObjectToCompare = value; }
        }
    
        public object ObjectToEvaluate
        {
            get { return this.m_ObjectToEvaluate; }
            set { this.m_ObjectToEvaluate = value; }
        }
    
        public override void ExecuteRule()
        {
            if (((IComparable)this.m_ObjectToEvaluate).CompareTo(this.m_ObjectToCompare) < 0)
                this.m_Result = true;
        }
    }
