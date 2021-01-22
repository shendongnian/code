    List<int> reverseMe = new List<int>();
    List<int> reversedList = new List<int>();
    reverseMe.Add(5);
    reverseMe.Add(16);
    reverseMe.Add(11);
    reverseMe.Add(3);
    reverseMe.Add(8);
    reverseMe.Add(4);
    int pivotPoint = 3;
    for (int c = 0; c < reverseMe.Count; c++)
    {
        if (c >= pivotPoint)
        {
            reversedList.Add(reverseMe[reverseMe.Count - c + pivotPoint - 1]);
        }
        else
        {
            reversedList.Add(reverseMe[c]);
        }
    } 
