    public class MachineModel
    {
        public class Snapshot
        {
            int _mmPrivateField;
            
            public Snapshot(MachineModel mm) 
            { 
                // get mm's state
                _mmPrivateField = mm._privateField;
            }
            public void RestoreState(MachineModel mm) 
            { 
                // restore mm's state
                mm._privateField = _mmPrivateField;
            }
        }
        int _privateField;
        public Snapshot CurrentSnapshot
        {
            get { return new Snapshot(this); }
        }
        public void RestoreState(Snapshot ss)
        {
            ss.Restore(this);
        }
    }
