    ///<summary>use Bar property instead</summary> 
    string bar;
    ///<summary>Lazy gets the value of Bar and stores it in bar</summary>
    string Bar {
        get {
            // logic to lazy load bar  
            return bar; 
        }
    }
