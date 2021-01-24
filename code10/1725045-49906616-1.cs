        class Derived : ExportReservationsToFtpRequestOld {
        
            public new int A { get; set; }
            public new long B { get; set; }
        }
    or even:
        class Derived : ExportReservationsToFtpRequestOld {
        
            public new virtual int A { get; set; }
            public new virtual long B { get; set; }
        }
        // with:
        class Derived2 : Derived {
        
            public override int A { get; set; }
            public override long B { get; set; }
        }
