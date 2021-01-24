    // Script name : MyCustomList.cs
    using UnityEngine;
    using System;
    using System.Collections.Generic; // Import the System.Collections.Generic class to give us access to List<>
     
    public class MyCustomList: MonoBehaviour { 
        //This is our list we want to use to represent our class as an array.
        public List<MyClass> MyList = new List<MyClass>(1);
    }
