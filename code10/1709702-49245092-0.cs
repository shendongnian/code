    string[] array1 = { "a", "b", "c", "d" };
    string[] array2 = { "y", "c", "h", "f" };
    var intersect = array1.Intersect(array2); // 1
    array1 = array1.Except(intersect).ToArray(); //2
    array2 = array2.Except(intersect).ToArray(); //2
