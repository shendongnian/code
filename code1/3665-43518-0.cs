        public static bool IsEqual(this List<int> InternalList, List<int> ExternalList)
        {
            if (InternalList.Count != ExternalList.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < InternalList.Count; i++)
                {
                    if (InternalList[i] != ExternalList[i])
                        return false;
                }
            }
            return true;
        }
