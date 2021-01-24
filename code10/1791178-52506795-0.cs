    for (var i = 0; i < arr.Length; i++)
    {
        // Split the array item on the `=` character.
        // This results in an array of two items ("a" and "01" for the first item)
        var tmp = arr[i].Split('=');
        // If there are fewer than 2 items in the array, there was not a =
        // character to split on, so continue to the next item.
        if (tmp.Length < 2) 
        {
            continue;
        }
    
        // Try to parse the second item in the tmp array (which is the number
        // in the provided example input) as an Int32.
        int num;
        if (Int32.TryParse(tmp[1], out num))
        {
            // If the parse is succesful, assign the int to the corresponding
            // index of the new array.
            newArr[i] = num;
        }
    }
