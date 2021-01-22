        public bool CompareStringLists(List<string> list1, List<string> list2)
        {
            if (list1.Count != list2.Count) return false;
            
            foreach(string item in list1)
            {
                if (!list2.Contains(item)) return false;
            }
            return true;
        }
