     string[,] SortedStudentArray = new string[FullList.Count, 11];
        //Line Counter
        int SSAPos = 0;
        // For every element in FullList
        foreach (var item in FullList)
        {
            //For each user in userArray
            for (int y = 0; y < Userdata.userArray.Length; y++)
            {
                if (Userdata.userArray[y][0] == item)
                {
                    for (int n = 0; n < Userdata.userArray[y].Length; n++)
                    {
                        SortedStudentArray[SSAPos, n] = Userdata.userArray[y][n];
                    }
                    SSAPos +=1; 
                    break;
                }
            }
