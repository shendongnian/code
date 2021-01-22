    using (MyDisposable blah = new MyDisposable())
    {
    	int.Parse("!"); // <- calls "Dispose" after the error.
    	return; // <-- calls Dispose before returning.
    }
