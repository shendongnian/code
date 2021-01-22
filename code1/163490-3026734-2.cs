	/// <summary>
	/// Doubleton
	/// </summary>
	public sealed class Doubleton
	{
		const int MaxInstances = 2;
		static volatile Hashtable instances = new Hashtable();
		static volatile int PreviousInstanceNumber = MaxInstances;
		
		#region Constructor
		Doubleton()
		{
		}
		#endregion
	
		#region Properties
		/// <summary>
		/// Get 1 of 2 instances of a Doubleton
		/// </summary>
		public static Doubleton Instance
		{
			get
			{
				lock (instances.SyncRoot)
				{
					int instanceNumber = PreviousInstanceNumber == MaxInstances ? 1 : ++PreviousInstanceNumber;
									
					// if it doesn't exist, create it
					if (instances[instanceNumber] == null)
					{
						instances[instanceNumber] = new Doubleton();
					}
					
					PreviousInstanceNumber = instanceNumber;
									
					return (Doubleton)instances[instanceNumber];
				}
			}
		}
		#endregion
		
		/// <summary>
		/// Get the index of the Doubleton
		/// </summary>
		/// <returns></returns>
		public int GetInstanceIndex()
		{
			lock (instances.SyncRoot)
			{
				for (int i = 1; i <= MaxInstances; i++)
				{
					if (instances[i] != null && instances[i].Equals(this))
					{
						return i;
					}
				}
			}
			
			return -1;
		}
	}
