    string[] list1 = { "a","b","c","d","e"};
    string[] list2 = { "d", "e", "f", "g" };
    string[] newElements = list2.Except(list1).ToArray();
    string[] commonElements = list2.Intersect(list1).ToArray();
    string[] removedElements = list1.Except(list2).ToArray(); 
