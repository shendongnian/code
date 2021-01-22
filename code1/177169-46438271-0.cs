    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    
    namespace name.domain.some{
        class SomeClass : ReactiveObject {
            [Reactive]
            public string SomeProperty { get; set; }
        }
    }
