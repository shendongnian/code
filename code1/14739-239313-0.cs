    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    // I only added this to use a lazier "collection initializer" below,
    // which needs an Add(string) method...
    class ApproverCollection : Collection<Approver> {
        public void Add(string name) { Add(new Approver(name)); }
    }
    class Request {
        public Request() { Approvers = new ApproverCollection(); }
        public ApproverCollection Approvers { get; private set; }
    }
    class Approver {
        public Approver(string name) { Name = name; }
        public string Name { get; set; }
    }
    static class Program {
        static void Main() {
            Request req = new Request {
                Approvers = {"Mathew", "Mark", "Luke", "John"}
            };
            req.ShowState("Initial");
            req.Approvers.Insert(2, new Approver("Peter"));
            req.ShowState("Inserted Peter");
            Approver mark = req.Approvers.Single(x => x.Name == "Mark");
            req.Approvers.Remove(mark);
            req.ShowState("Removed Mark");
            Approver john = req.Approvers.Single(x => x.Name == "John");
            req.Approvers.Remove(john);
            req.Approvers.Insert(0, john);
            req.ShowState("Moved John");
        }
        static void ShowState(this Request request, string caption) {
            Console.WriteLine();
            Console.WriteLine(caption);
            int pos = 1;
            foreach(Approver a in request.Approvers) {
                Console.WriteLine("{0}: {1}", pos++, a.Name);
            }
        }
    }
