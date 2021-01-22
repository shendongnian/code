            int i = 0;
            while (i < list.Count())
            {
                if (list[i].predicate == true)
                {
                    list.RemoveAt(i);
                    continue;
                }
                i++;
            }
