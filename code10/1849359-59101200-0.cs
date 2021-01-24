    public class Person
	{
		public Person(string name, GenderType gender)
		{
			Name = name;
			Gender = gender;
		}
		public string Name { get; set; }
		public GenderType Gender { get; set; }
	}
	[Flags]
	public enum GenderType : byte
	{
		Male = 1,
		Female = 2,
		Both = Male | Female
	}
	public class Family
	{
		public Family(List<Person> people, Person familyHead = null)
		{
			People = people;
			FamilyHead = familyHead;
		}
		public List<Person> People { get; set; }
		public Person FamilyHead { get; set; }
	}
	#region Interfaces
	/// <summary>
	/// Interface for objects supporting the object graph reference.
	/// </summary>
	public interface ISurrogateWithReferenceId
	{
		/// <summary>
		/// Gets or sets the id for the object referenced more than once during the process of serialization/deserialization.
		/// </summary>
		/// <remarks>Default value is -1.</remarks>
		int ReferenceId { get; set; }
	}
	#endregion
	public class PersonSurrogate : ISurrogateWithReferenceId
	{
		/// <summary>
		/// Standard constructor.
		/// </summary>
		public PersonSurrogate(string name, byte gender)
		{
			Name = name;
			Gender = gender;
			ReferenceId = -1;
		}
		/// <summary>
		/// Private constructor for object graph reference handling.
		/// </summary>
		private PersonSurrogate(int referenceId)
		{
			ReferenceId = referenceId;
		}
		public string Name { get; set; }
		public byte Gender { get; set; }
		#region object graph reference
		/// <summary>
		/// Gets the unique id assigned to the surrogate during the process of serialization/deserialization to handle object graph reference.
		/// </summary>
		/// <remarks>Default value is -1.</remarks>
		public int ReferenceId { get; set; }
		public override bool Equals(object obj)
		{
			return base.Equals(obj) || (ReferenceId > 0 && obj is ISurrogateWithReferenceId oi && oi.ReferenceId == ReferenceId);
		}
		public override int GetHashCode()
		{
			if (ReferenceId > 0)
				return ReferenceId;
			return base.GetHashCode();
		}
		#endregion object graph reference
		protected virtual bool CheckSurrogateData(GenderType gender)
		{
			return gender == GenderType.Both || (GenderType)Gender == gender;
		}
		#region Static Methods  
		/// <summary>
		/// Converts the surrogate to the related object during the deserialization process.
		/// </summary>        
		public static implicit operator Person(PersonSurrogate surrogate)
		{
			if (surrogate == null) return null;
			if (FamilySerializer.GetCachedObject(surrogate) is Person obj)
				return obj;
			obj = new Person(surrogate.Name, (GenderType)surrogate.Gender);
			FamilySerializer.AddToCache(surrogate, obj);
			return obj;
		}
		/// <summary>
		/// Converts the object to the related surrogate during the serialization process.
		/// </summary>
		public static implicit operator PersonSurrogate(Person source)
		{
			if (source == null) return null;
			if (FamilySerializer.GetCachedObjectWithReferenceId(source) is PersonSurrogate surrogate)
			{
				surrogate = new PersonSurrogate(surrogate.ReferenceId);
			}
			else
			{
				surrogate = new PersonSurrogate(source.Name, (byte)source.Gender);
				FamilySerializer.AddToCache(source, surrogate);
			}
			return surrogate;
		}
		#endregion    
	}
	public class FamilySurrogate
	{
		public FamilySurrogate(List<Person> people, Person familyHead)
		{
			People = people;
			FamilyHead = familyHead;
		}
		public List<Person> People { get; set; }
		public Person FamilyHead { get; set; }
		#region Static Methods
		public static implicit operator Family(FamilySurrogate surrogate)
		{
			if (surrogate == null) return null;
			return new Family(surrogate.People, surrogate.FamilyHead);
		}
		public static implicit operator FamilySurrogate(Family source)
		{
			return source == null ? null : new FamilySurrogate(source.People, source.FamilyHead);
		}
		#endregion
	}
