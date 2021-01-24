    /// <summary>
	/// Class with model for protobuf serialization
	/// </summary>
	public class FamilySerializer
	{
		public GenderType GenderToInclude;
		public FamilySerializer(Family family, GenderType genderToInclude = GenderType.Both)
		{
			GenderToInclude = genderToInclude;
			Family = family;
			Init();
		}
		private void Init()
		{
			Model = RuntimeTypeModel.Create();
			FillModel();
			Model.CompileInPlace();        
		}
		public FamilySerializer()
		{
			Init();
		}
		public Family Family { get; set; }
		public RuntimeTypeModel Model { get; protected set; }
		protected virtual void FillModel()
		{
			Model = RuntimeTypeModel.Create();
			Model.Add(typeof(Family), false)
				.SetSurrogate(typeof(FamilySurrogate));
			MetaType mt = Model[typeof(FamilySurrogate)];
			mt.Add(1, "People"); // This is a list of Person of course
			//mt.AddField(2, "FamilyHead").AsReference = true;  // Exception "A reference-tracked object changed reference during deserialization" - because using surrogate.            
			mt.Add(2, "FamilyHead");
			mt.UseConstructor = false;
			Model.Add(typeof(Person), false)
				.SetSurrogate(typeof(PersonSurrogate));
			mt = Model[typeof(PersonSurrogate)]
				.Add(1, "Name")
				.Add(2, "Gender")
				.Add(3, "ReferenceId");        
			mt.UseConstructor = false; // Avoids to use the parameter-less constructor.
		}
		#region Cache
		static FamilySerializer()
		{
			ResizeCache();
		}
		/// <summary>
		/// Resizes the cache for object graph reference handling.
		/// </summary>
		/// <param name="size"></param>
		public static void ResizeCache(int size = 500)
		{
			if (_cache != null)
			{
				foreach (var pair in _cache)
				{
					pair.Value.ResetCache();
				}
			}
			_cache = new ConcurrentDictionary<int, FamilySerializerCache>();
			for (var i = 0; i < size; i++)
				_cache.TryAdd(i, new FamilySerializerCache());
		}
		private static ConcurrentDictionary<int, FamilySerializerCache> _cache;
		/// <summary>
		/// For internal use only. Adds the specified key and value to the serializer cache for the current thread during the serialization process.
		/// </summary>
		/// <param name="objKey">The the element to add as key.</param>
		/// <param name="objValue">The value of the element to add.</param>
		/// <remarks>The <see cref="ISurrogateWithReferenceId.ReferenceId"/> is updated for <see cref="objValue"/></remarks>
		public static void AddToCache(object objKey, ISurrogateWithReferenceId objValue)
		{
			_cache[Thread.CurrentThread.ManagedThreadId].AddToCache(objKey, objValue);
		}
		/// <summary>
		/// For internal use only. Adds the specified key and value to the serializer cache for the current thread during the serialization process.
		/// </summary>
		/// <param name="objKey">The the element to add as key.</param>
		/// <param name="objValue">The value of the element to add.</param>
		/// <remarks>The <see cref="ISurrogateWithReferenceId.ReferenceId"/> is updated for <see cref="objKey"/></remarks>
		public static void AddToCache(ISurrogateWithReferenceId objKey, object objValue)
		{
			_cache[Thread.CurrentThread.ManagedThreadId].AddToCache(objKey, objValue);
		}
		/// <summary>
		/// For internal use only. Resets the cache for the current thread.
		/// </summary>
		public static void ResetCache()
		{
			_cache[Thread.CurrentThread.ManagedThreadId].ResetCache();
		}
		/// <summary>
		/// For internal use only. Gets the <see cref="ISurrogateWithReferenceId"/> associated with the specified object for the current thread.
		/// </summary>
		/// <param name="obj">The object corresponding to the value to get.</param>
		/// <returns>The related ISurrogateWithReferenceId if presents, otherwise null.</returns>
		public static ISurrogateWithReferenceId GetCachedObjectWithReferenceId(object obj)
		{
			return _cache[Thread.CurrentThread.ManagedThreadId].GetCachedObjectWithReferenceId(obj);
		}
		/// <summary>
		/// For internal use only. Gets the object associated with the specified <see cref="ISurrogateWithReferenceId"/>.
		/// </summary>
		/// <param name="surrogateWithReferenceId">The <see cref="ISurrogateWithReferenceId"/> corresponding to the object to get.</param>
		/// <returns>The related object if presents, otherwise null.</returns>
		public static object GetCachedObject(ISurrogateWithReferenceId surrogateWithReferenceId)
		{
			return _cache[Thread.CurrentThread.ManagedThreadId].GetCachedObject(surrogateWithReferenceId);
		}
		#endregion Cache
		public void Save(string fileName)
		{            
			using (Stream s = File.Open(fileName, FileMode.Create, FileAccess.Write))
			{
				Model.Serialize(s, Family, new ProtoBuf.SerializationContext(){Context = this});
			}
		}
		public void Open(string fileName)
		{
			using (Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read))
			{
				Family = (Family)Model.Deserialize(s, null, typeof(Family), new ProtoBuf.SerializationContext(){Context = this});
			}
		}
	}
