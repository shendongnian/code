    ...
    foreach (string line in lines)
    {
        string[] strArr = null;
        string[] newArray = new string[7];  
        strArr = line.Split(splitchar);
        Array.Copy(strArr, newArray, 7);
        // Call DB function, passing newArray
        saveToDB(newArray);
    }
    ...
