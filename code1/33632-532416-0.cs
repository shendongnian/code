    interface ISimpleInterface
    {
    	string ErrorMessage { get; set; }
    }
    interface IExtendedInterface : ISimpleInterface
    {
    	string SomeOtherProperty { get; set; }
    }
