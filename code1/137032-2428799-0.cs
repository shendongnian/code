            List<int> n = new List<int>() { 1, 2, 3, 4, 9, 2, 39, 482, 19283, 19, 23, 1, 29 };
            List<int> toFind = new List<int>() { 1, 2, 3, 4 };
            if (n.Skip(indextostart).Take(4).ToList()==toFind)
            {
                n.RemoveRange(indextostart,4);
            }
