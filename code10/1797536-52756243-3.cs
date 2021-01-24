    string[] names = new string[]{"John", "Paul", "Ringo", "George"};
    int[] grades = new[] {3, 4, 3,2};
    int[] winnersandloser = new int[4];
    for (int i = 1; i < grades.Length; i++) //note starting at position 1 so I dont need to handle index out of bounds inside the for loop
    {
        if (grades[i] > grades[i - 1])
        {
            winnersandloser[i]++;
        }
        else
        {
            winnersandloser[i - 1]++;
        }
    }
