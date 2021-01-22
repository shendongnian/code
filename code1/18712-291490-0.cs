    private MyType _someVariable = TenantType.None;
    [NotNullValidator(MessageTemplate = "Some Variable can not be empty")]
    public MyType SomeVariable {
    	get {
    		return _someVariable;
    	}
    	set {
    		_someVariable = value;
    	}
    }
