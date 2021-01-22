    public class SuspendAwareTreeView : TreeView    
    {
        public readonly T RealControl;
        private int suspendCount;
        public bool IsSuspended 
        { 
            get { return suspendCount > 0; }
        }
    
        public Suspendable(T real) { this.RealControl = real; }
     
        public void SuspendLayout() 
        { 
            this.suspendCount++;
            this.RealControl.SuspendLayout();
        }
    
        public void ResumeLayout() 
        { 
            this.RealControl.ResumeLayout();
            this.suspendCount--;
        }
    }
