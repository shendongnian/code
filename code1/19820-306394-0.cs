	public delegate void MyDelegate(object sender, EventArgs e, string otherParameterIWant);
	//...Inside the class
	public event MyDelegate myEvent;
	//...Inside a method
	if (myEvent != null)
		myEvent(this, new EventArgs(), "Test for SO");
