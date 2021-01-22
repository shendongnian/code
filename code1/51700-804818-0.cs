    public class InternalEntryLevelCandidate : EntryLevelCandidate {
        private  InternalCandidate internalCandidateDelegate
            = new InternalCandidate();
        public decimal CurrentMid { 
            get { return internalCandidateDelegate.CurrentMid; }
            set { internalCandidateDelegate.CurrentMid = value; }
        }
    
        public decimal CurrentMax {
            get { return internalCandidateDelegate.CurrentMax }
        }
    }
