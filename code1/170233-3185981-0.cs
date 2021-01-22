        // Calculates the depth of the layer in the object graph
        public int GetIndex()
        {
            int ct = 0;
            ViewLayer pos = this;
            while (pos.Parent != null)
            {
                ct++;
                pos = pos.Parent;
            }
            return ct;
        }
