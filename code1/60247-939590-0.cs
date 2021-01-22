    interface IPPatherInterface // Inside of Raven.
    {
        void Foo();
    }
    class PPatherClass : IPPatherInterface // Inside of PPather
    {
        // ...
    }
    class SomeRavenClass // Static maybe? Inside of Raven
    {
        void SupplyPPatherClass(IPPatherInterface item) { ... }
    }
