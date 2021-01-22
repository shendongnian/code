    // Convert An array of string  to a list of string
    public static List<string> ConnvertArrayToList(this string [] array) {
        // DECLARE a list of string and add all element of the array into it
        List<string> myList = new List<string>();
        foreach( string s in array){
            myList.Add(s);
        }
        return myList;
    } 
