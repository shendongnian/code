        public bool DoesContain(ArrayList list, object element)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                if (list[i].Equals(element))
                {
                    return true;
                }
                return false;
            }
        }
