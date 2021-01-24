    ...
    string[] strArr;
    string[] newArray = new string[7];  
    foreach (string line in lines)
    {
        strArr = line.Split(splitchar);
        Array.Copy(strArr, newArray, 7);
        // Call DB function, passing newArray
        saveToDB(newArray);
    }
    ...
