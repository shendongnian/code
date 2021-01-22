    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Context ctx = new Context();
                ctx.BranchInfos.Add(new BranchInfo() { Type = "NonService", BranchID = 20, Parent = 0 });
                ctx.BranchInfos.Add(new BranchInfo() { Type = "Service", BranchID = 21, Parent = 20 });
                ctx.BranchInfos.Add(new BranchInfo() { Type = "NonService", BranchID = 30, Parent = 20 });
    
                int branchId = 21;
    
                var t = (from a in ctx.BranchInfos
                         where a.BranchID == branchId
                         select a.Type != BranchType.Service.ToString() ? a :
                         (from b in ctx.BranchInfos
                          where b.BranchID == a.Parent
                          select b).Single()).Single();
    
                Console.WriteLine(t.BranchID); // Prints 20
            }
    
            class Context
            {
                public List<BranchInfo> BranchInfos = new List<BranchInfo>();
            }
    
            class BranchInfo
            {
                public string Type;
                public int BranchID;
                public int Parent;
            }
    
            enum BranchType
            {
                Service = 0
            }
        }
    }
