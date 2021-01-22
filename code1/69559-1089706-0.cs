    if (checkSomething())
    {
    //handle clicks on myControl
    myControl.Click += MyEventHanderMethod;
    }
    else
    {
    //stop handling clicks on myControl
    myControl.Click -= MyEventHanderMethod;
    }
