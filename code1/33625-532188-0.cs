	class Foo
	{
		string ISimpleInterface.ErrorMsg
		{ get... }
		
		string IExtendedInterface.ErrorMsg
		{ get... set... }
		
		string IExtendedInterface.SomeOtherProperty
		{ get... set... }
	}
