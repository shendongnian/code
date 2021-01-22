    ///<summary>
    ///Get the Text value of the object
    ///NOTE: Setting the value is not supported by this class but may be supported by child classes
    ///</summary>
    public virtual string Text 
    {
        get { return text; }
        set { }
    }
    //using the class
    BaseClass.Text = "Wibble";
    if (BaseClass.Text == "Wibble")
    {
        //Won't get here (unless the default value is "Wibble")
    }
