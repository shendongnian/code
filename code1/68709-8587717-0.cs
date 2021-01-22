        subfolders.Sort();
        public void SortByLength(List<string> subfolders)
        {
            int l = 0;
            int l2 = 0;
            for (int i = subfolders.Count() - 1; i != 0; i--)
            {
                l = subfolders[i].Length;
                if (i != subfolders.Count() - 1 && l2 < l)
                {
                    string folder = subfolders[i + 1];
                    subfolders.RemoveAt(i + 1);
                    subfolders.Insert(0, folder);
                }
                l2 = l;
            }
        }
