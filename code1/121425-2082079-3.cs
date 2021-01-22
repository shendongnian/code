    namespace My.Dal.Namespace {
        // add a type attribute to SomeEntity
        [XmlInclude(typeof(SomeDerivedEntity))]
        partial class SomeEntity { } 
    }
