        enum ProcID { Unassigned = 0 }
        enum TenderID { Unassigned = 0 }
        void Test()
        {
            ProcID p = 0;
            TenderID t = 0; <-- 0 is assignable to every enum
            p = (ProcID)3;  <-- need to explicitly convert
            if (p == t)  <-- operator == cannot be applied
                t = -1;  <-- cannot implicitly convert
            DoProc(p);
            DoProc(t);   <-- no overloaded method found
            DoTender(t);
        }
        void DoProc(ProcID p)
        {
        }
        void DoTender(TenderID t)
        {
        }
