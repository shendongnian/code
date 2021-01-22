    using System;
    
    // interface for the "inner singleton"
    interface IPuppet {
        void DoSomething();
    }
    class MasterOfPuppets {
        // private class: only MasterOfPuppets can create
        private class PuppetImpl : IPuppet {
            public void DoSomething() {
            }
        }
        static MasterOfPuppets _instance = new MasterOfPuppets();
        public static MasterOfPuppets Instance {
            get { return _instance; }
        }
        // private set accessor: only MasterOfPuppets can replace instance
        public IPuppet Puppet {
            get;
            private set;
        }
    }
    class Program {
        public static void Main(params string[] args) {
            // access singleton and then inner instance
            MasterOfPuppets.Instance.Puppet.DoSomething();
        }
    }
