    class Group : IEquatable<Group>
 	{
        private readonly Collection<int> userIds;
 
 		public ReadOnlyCollection<int> UserIds { get; }
 		public int CreateByUserId { get; }
 		public int HashKey { get; }
        public Group(int createByUserId, IList<int> createdByUserIDs)
 	    {
 		    CreateByUserId = createByUserId;
 		    userIds = createdByUserIDs != null 
               ? new Collection<int>(createdByUserIDs)
               : new Collection<int>();
            UserIds = new ReadOnlyCollection<int>(userIds);
            
 		    HashKey = GetHashCode();
        }
        public void AddUserID(int userID)
        {
            userIds.Add(userID);
            HashKey = GetHashCode();
        }
        //IEquatable<T> implementation is generally a good practice in such cases, especially for value types
 		public override bool Equals(object obj) => Equals(obj as Group);
 		
 	     public bool Equals(Group objectToCompare)
 	     {
 		    if (objectToCompare == null)
 			    return false;
 
 		    if (ReferenceEquals(this, objectToCompare))
 			    return true;
 
 		    if (UserIds.Count != objectToCompare.UserIds.Count || CreateByUserId != objectToCompare.CreateByUserId)
 			    return false;
 
 		    //If you need equality when order matters - use this
 		    //return UserIds.SequenceEqual(objectToCompare.UserIds);
 
 
 		    //This is for set equality. If this is your case and you don't allow duplicates then I would suggest to use HashSet<int> or ISet<int> instead of Collection<int>
 		    //and use their methods for more concise and effective comparison
 		    return UserIds.All(id => objectToCompare.UserIds.Contains(id)) && objectToCompare.UserIds.All(id => UserIds.Contains(id));
 	    }
 	    public override int GetHashCode()
		{
 			unchecked // to suppress overflow exceptions
 			{
 				int hash = 17;			
 				hash = hash * 23 + CreateByUserId.GetHashCode();
 
 				foreach (int userId in UserIds)
 					hash = hash * 23 + userId.GetHashCode();
 
 				return hash;
 			}
 		}
 	}
