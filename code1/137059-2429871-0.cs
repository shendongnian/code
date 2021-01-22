    namespace N1.N2 {}
    namespace N3
    {
       using R1 = N1;         // OK
       using R2 = N1.N2;      // OK
       using R3 = R1.N2;      // Error, R1 unknown
    }
