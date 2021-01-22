	internal class CleanerRef
	{
		~CleanerRef()
		{
			if (handle.IsAllocated)
				handle.Free();
		}
	
		public CleanerRef(WeakDictionaryCleaner cleaner, WeakDictionary dictionary)
		{
			handle = GCHandle.Alloc(cleaner, GCHandleType.WeakTrackResurrection);
			Dictionary = dictionary;
		}
		public bool IsAlive
		{
			get {return handle.IsAllocated && handle.Target != null;}
		}
		public object Target
		{
			get {return IsAlive ? handle.Target : null;}
		}
		GCHandle handle;
		public WeakDictionary Dictionary;
	}
	internal class WeakDictionaryCleaner
	{
		public WeakDictionaryCleaner(WeakDictionary dict)
		{
			refs.Add(new CleanerRef(this, dict));
		}
	
		~WeakDictionaryCleaner()
		{
			foreach(var cleanerRef in refs)
			{
				if (cleanerRef.Target == this)
				{
					cleanerRef.Dictionary.ClearGcedEntries();
					refs.Remove(cleanerRef);
					break;
				}
			}
		}
		private static readonly List<CleanerRef> refs = new List<CleanerRef>();
	}
