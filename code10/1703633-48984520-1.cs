    A a = null;
    if(/*user input*/)
    {   
       a = new A();
    }
    else
    {
       b = new B();
    }
    // this results in A, because that's the variable type
    typeof(a); 
    // this results in either A or B depending on how he "if" went,
    // because that's the actual type of the instance
    a.GetType(); 
