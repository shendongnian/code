    // Script name : MyCustomList.cs
    using UnityEngine;
    using System;
    using System.Collections.Generic; // Import the System.Collections.Generic class to give us access to List<>
     
    public class MyCustomList: MonoBehaviour { 
        //This is our list we want to use to represent our class as an array.
        public List<MyListItem> MyList = new List<MyListItem>(1);
     
        void AddNew(){
            //Add a new index position to the end of our list
            MyList.Add(new MyListItem());
        }
     
        void Remove(int index){
            //Remove an index position from our list at a point in our list array
            MyList.RemoveAt(index);
        }
    }
