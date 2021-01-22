    class Blur
        {
            private static int count = 0;
            private static Queue<int> deletions = new Queue<int>();
    
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    Delete();
                }
            }
    
            private int assigned;
    
            public Blur()
            {
                if (deletions.Count > 0)
                {
                    assigned = deletions.Dequeue();
                }
                else
                {
                    assigned = count++;
                }
                _name = "Blur" + assigned.ToString();
            }
    
            public void Delete()
            {
                if (assigned >= 0)
                {
                    deletions.Enqueue(assigned);
                    assigned = -1;
                }
            }
        }
