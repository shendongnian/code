        public override bool Equals(object obj)
        {
            return this.Name == (obj as Item).Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        public bool Check(Item obj)
        {
            if (this.Name != obj.Name)
                return false;
            //if the lists arent of the same length then they 
            //obviously dont contain the same items, and besides 
            //there would be an exception on the next check
            if (this.SubItems.Count != obj.SubItems.Count)
                return false;
            for (int i = 0; i < this.SubItems.Count; i++)
                if (this.SubItems[i] != obj.SubItems[i])
                    return false;
            return true;
        }
