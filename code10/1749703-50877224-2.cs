        public static bool IsDone(string[] gridValues, string O_X)
        {
            if (
                IsEqual(gridValues, O_X, 0, 1, 2) ||
                IsEqual(gridValues, O_X, 3, 4, 5) ||
                IsEqual(gridValues, O_X, 6, 7, 8) ||
                IsEqual(gridValues, O_X, 0, 4, 8) ||
                IsEqual(gridValues, O_X, 6, 4, 2) ||
                IsEqual(gridValues, O_X, 0, 3, 6) ||
                IsEqual(gridValues, O_X, 1, 4, 7) ||
                IsEqual(gridValues, O_X, 2, 5, 8))
                return true;
            return false;
        }
        public static bool IsEqual(string[] A, string a, params int[] index)
        { 
            for (int i = 0; i < index.Length; i++)
                if (A[index[i]] != a)
                    return false;
            return true;
        } 
