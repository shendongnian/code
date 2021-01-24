        public int IndexOf(string text)
        {
            int counter = -1;
            for (Node i = Head; i != null; i = i.Next)
            {
                counter++;
                if (text == i.Text)
                {
                    return counter;
                }                
            }
            return -1;
        }
