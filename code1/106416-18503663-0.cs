            var ranges = activeworkBook.Names;
            int i = 1;
            while (i <= ranges.Count)
            {
                String currentName = ranges.Item(i, Missing.Value, Missing.Value).Name;
                if (currentName.Equals(namedRangeToBeDeleted))
                {
                    ranges.Item(i, Type.Missing, Type.Missing).Delete();
                }
                else
                {
                    i++;
                }
            }
