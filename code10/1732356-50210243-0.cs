    class Group
    {
        public Collection<int> UserIds { get; set; }
        public int CreateByUserId { get; set; }
    
        public override bool Equals(object obj)
        {
            Group objectToCompare = (Group)obj;
    
            if (this.UserIds.Count != objectToCompare.UserIds.Count)
                return false;
    
            if (this.CreateByUserId != objectToCompare.CreateByUserId)
                return false;
    
            foreach (int ownUserId in this.UserIds)
                if (!objectToCompare.UserIds.Contains(ownUserId))
                    return false;
            //some elements might be double, i.e. 1: 1,2,2 vs 2: 1,2,3 => not equal. cross check to avoid this error
            foreach (int foreignUserId in objectToCompare.UserIds)
                if (!this.UserIds.Contains(foreignUserId))
                    return false;
    
            return true;
        }
    
        public override int GetHashCode()
        {
            int sum = CreateByUserId;
            foreach (int userId in UserIds)
                sum += userId;
    
            return sum;
        }
    }
