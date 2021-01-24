	public sealed class WorkItem : IEquatable<WorkItem>
	{
		private readonly int _id;
		private readonly string _name;
		private readonly DateTime _dateCreated;
	
		public int Id { get { return _id; } }
		public string Name { get { return _name; } }
		public DateTime DateCreated { get { return _dateCreated; } }
	
		public WorkItem(int id, string name, DateTime dateCreated)
		{
			_id = id;
			_name = name;
			_dateCreated = dateCreated;
		}
	
		public override bool Equals(object obj)
		{
			if (obj is WorkItem)
				return Equals((WorkItem)obj);
			return false;
		}
	
		public bool Equals(WorkItem obj)
		{
			if (obj == null) return false;
			if (!EqualityComparer<int>.Default.Equals(_id, obj._id)) return false;
			if (!EqualityComparer<string>.Default.Equals(_name, obj._name)) return false;
			if (!EqualityComparer<DateTime>.Default.Equals(_dateCreated, obj._dateCreated)) return false;
			return true;
		}
	
		public override int GetHashCode()
		{
			int hash = 0;
			hash ^= EqualityComparer<int>.Default.GetHashCode(_id);
			hash ^= EqualityComparer<string>.Default.GetHashCode(_name);
			hash ^= EqualityComparer<DateTime>.Default.GetHashCode(_dateCreated);
			return hash;
		}
	
		public override string ToString()
		{
			return String.Format("{{ Id = {0}, Name = {1}, DateCreated = {2} }}", _id, _name, _dateCreated);
		}
	
		public static bool operator ==(WorkItem left, WorkItem right)
		{
			if (object.ReferenceEquals(left, null))
			{
				return object.ReferenceEquals(right, null);
			}
	
			return left.Equals(right);
		}
	
		public static bool operator !=(WorkItem left, WorkItem right)
		{
			return !(left == right);
		}
	}
