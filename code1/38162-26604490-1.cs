    public void myMethod(int integer) {		
		// Do something
	}
	public void passFunction(System.Action methodWithParameters) {
		// Invoke
		methodWithParameters();
	}
	// ...
	// Pass anonymous method using lambda expression
	passFunction(() => myMethod(1234));
