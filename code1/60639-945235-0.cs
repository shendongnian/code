        public bool AreEqual<T>(IList<T> A, IList<T> B)
        {
            if (A.Count != B.Count)
                return false;
            for (int i = 0; i < A.Count; i++)
                if (!A[i].Equals(B[i])) 
                    return false;
        }
