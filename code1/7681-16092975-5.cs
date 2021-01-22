    namespace MyCorp.TheProduct.SomeModule.Utilities
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using MyCorp.TheProduct;                           // MyCorp can be left out; this using is NOT redundant
        using MyCorp.TheProduct.OtherModule;               // MyCorp.TheProduct can be left out
        using MyCorp.TheProduct.OtherModule.Integration;   // MyCorp.TheProduct can be left out
        using ThirdParty;
        class C
        {
            Ambiguous a;
        }
    }
