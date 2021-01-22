	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Collections.Specialized;
	using System.Reflection;
	using log4net;
	using log4net.Config; 
	namespace DH
	{
		//DH - DataHolders
		/// <summary>
		/// This class models a storage structure for objects queriable by id 
		/// </summary>
		public class ObjectPool
		{
			#region Props
			private int totalCount;
			public int TotalCount
			{
				get
				{
					return totalCount;
				}
			}
			public int ID { get; set; }
			#endregion Props
			public ObjectPool ()
			{
				m_pool = new Dictionary<Type, Dictionary<Int32, Object>> ();
			}
			private Dictionary<Type, Dictionary<Int32, Object>> m_pool;
			public void AddItem<T> ( Int32 pID, T value )
			{
				Type myType = typeof ( T );
				if (!m_pool.ContainsKey ( myType ))
				{
					m_pool.Add ( myType, new Dictionary<int, object> () );
					m_pool[myType].Add ( pID, value );
					totalCount++;
					return;
				}
				if (!m_pool[myType].ContainsKey ( pID ))
				{
					m_pool[myType].Add ( pID, value );
					totalCount++;
					return;
				}
				m_pool[myType][pID] = value;
				totalCount++;
				//Utils.Debugger.WriteIf("Adding 1 to pool count , pool count is " + this.totalCount);
			}
			public void AddItem<T> ( T value )
			{
				Int32 pID = totalCount ;
				Type myType = typeof ( T );
				if (!m_pool.ContainsKey ( myType ))
				{
					m_pool.Add ( myType, new Dictionary<int, object> () );
					m_pool[myType].Add ( pID, value );
					totalCount++;
					return;
				}
				if (!m_pool[myType].ContainsKey ( pID ))
				{
					m_pool[myType].Add ( pID, value );
					totalCount++;
					return;
				}
				m_pool[myType][pID] = value;
				totalCount++;
				//Utils.Debugger.WriteIf("Adding 1 to pool count , pool count is " + this.totalCount);
			}
			public bool RemoveItem<T> ( Int32 pID )
			{
				Type myType = typeof ( T );
				if (!m_pool.ContainsKey ( myType ))
					return false;
				if (!m_pool[myType].ContainsKey ( pID ))
					return false;
				totalCount--;
				return m_pool[myType].Remove ( pID );
			}
			public bool ContainsKey<T> ( Int32 pID )
			{
				Type myType = typeof ( T );
				if (!m_pool.ContainsKey ( myType ))
					return false;
				if (!m_pool[myType].ContainsKey ( pID ))
					return false;
				return m_pool[myType].ContainsKey ( pID );
			}
			public IEnumerable<T> GetItems<T> ()
			{
				Type myType = typeof ( T );
				if (!m_pool.ContainsKey ( myType ))
					return new T[0];
				return m_pool[myType].Values as IEnumerable<T>;
			}
			/// <summary>
			/// Gets the item.
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="pID">The p ID.</param>
			/// <returns></returns>
			/// <exception cref="KeyNotFoundException"></exception>
			public T GetItem<T> ( Int32 pID )
			{
				// will throw KeyNotFoundException if either of the dictionaries 
				// does not hold the required key
				return (T)m_pool[typeof ( T )][pID];
			}
			/// <summary>
			/// 
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="strPropMetaName"> the string representation of the </param>
			/// <param name="strPropValue"></param>
			/// <returns></returns>
			public T GetItemByPropertyValue<T> ( String strPropMetaName , String strPropValue)
			{
				Type myType = typeof ( T );
				for (int i = 0; i < this.TotalCount; i++)
				{
					if (!m_pool.ContainsKey ( myType ))
					{
						return default ( T );
					}
					else
					{
						if (this.ContainsKey<T> ( i ))
						{
							//get an item object having the same type
							T item = this.GetItem<T> ( i );
							//if the object has the same property -- check its value
							MemberInfo[] members = myType.GetMembers ();
							for (int j = 0; j < members.Length; j++)
							{
								logger.Info ( "members[j].Name is " + members[j].Name );
								//logger.Info ( ".MemberType.ToString() " + members[j].MemberType.ToString () );
								//logger.Info ( "members[j].GetType().ToString() " + members[j].GetType ().ToString () );
								//logger.Info ( " members[j].ToString () is " + members[j].ToString () );
								//logger.Info ( " members[j].ToString () is " + members[j] );
								if (members[j].Name.ToString ().Equals ( strPropMetaName ))
								{
							
									FieldInfo[] fi;
									fi = myType.GetFields ( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );
									
									foreach (FieldInfo f in fi)
									{
										//logger.Info ( "f.GetValue( obj ) is " + f.GetValue ( item ) );
										if ( f.GetValue ( item ).ToString().Equals(strPropValue))
											return (T)m_pool[typeof ( T )][i];
										else 
											continue ;
									} //eof foreach								
								}
								else
									continue;
							} //eof for j
						} //eof if 
						else
							continue;
					} //eof else if m_pool.ContainsKey
				}
				return default ( T );
			}
			private static readonly ILog logger =
	LogManager.GetLogger ( typeof ( DH.ObjectPool ) );
		} //eof class pool	
	} //eof namespace
	namespace PoolSample
	{
		class Program
		{
			private static readonly ILog logger =
	LogManager.GetLogger ( typeof ( Program ) );
			public static DH.ObjectPool pool = new DH.ObjectPool ();
			static void Main ( string[] args )
			{
				DOMConfigurator.Configure (); //tis configures the logger 
				Animal dog = new Animal () { Name = "Fido", ID = 1 };
				Vegetable carrot = new Vegetable { Color = "Orange", Identifier = 2, IsTasty = true };
				Mineral carbon = new Mineral () { UniqueID = 3, IsPoisonousToAnimal = false , Name="some"};
				HolderForStrings hfs = new HolderForStrings () { ID = 4, Value = "user_name", MetaName = "meta_nam" };
				HolderForStrings hfs1 = new HolderForStrings () { ID = 5, Value = "user_name", MetaName = "hfs1" };
				Mineral carbon1 = new Mineral () { UniqueID = 3, IsPoisonousToAnimal = false, Name = "some1" };
				pool.AddItem ( dog );
				pool.AddItem ( carrot );
				pool.AddItem ( hfs );
				pool.AddItem ( hfs1 );
				//pool.AddItem<Animal>(dog.ID, dog);
				//pool.AddItem<Vegetable>(carrot.Identifier, carrot);
				//pool.AddItem<Mineral> ( carbon );
				//pool.AddItem<HolderForStrings> ( 1, hfs );
				
				//logger.Info("Dog is in the pool -- this statement is " + pool.ContainsKey<Animal>(dog.ID));
				//logger.Info("hfs is in the pool -- this statement is " + pool.ContainsKey<HolderForStrings>(hfs.ID));
				//logger.Info("The hfs value is from the poos is " + pool.GetItem<HolderForStrings>(4).Value);
				//logger.Info("poo.GetItems is " + pool.GetItems<HolderForStrings>());
				#region while
				//for (int i = 0; i < pool.Count -1 ; i++)
				int i = 1;
				do
				{
					try
					{
						logger.Info ( "counting" );
						logger.Info ( " i is " + i.ToString () );
						if (pool.ContainsKey<Animal> ( i ))
						{
							logger.Info ( " I see animal which is " + pool.GetItem<Animal> ( i ).Name );
						}
						if (pool.ContainsKey<Vegetable> ( i ))
						{
							logger.Info ( " I see Vegetable which is " + pool.GetItem<Vegetable> ( i ).Color );
						}
						if (pool.ContainsKey<Mineral> ( i ))
						{
							logger.Info ( " I see Mineral which is " + pool.GetItem<Mineral> ( i ).IsPoisonousToAnimal );
						}
						if (pool.ContainsKey<HolderForStrings> ( i ))
						{
							logger.Info ( " I see string which is " + pool.GetItem<HolderForStrings> ( i ).Value );
						}
						//logger.Info("pool.GetItem<HolderForStrings>(4).Value); is " + pool.GetItem<Object>(i).ToString());
						i = i + 1;
					}
					catch (KeyNotFoundException e)
					{
						continue;
					}
				} //eof for 
				while (i < pool.TotalCount);
	#endregion while
				#region AddHolders
				////this is the success identifier
				//HoldInt16 holdVerifier = new HoldInt16()
				//{
				//  ID=0 ,
				//  MetaName = "ret",
				//  Value = 0
				//};
				//pool.AddItem<HoldInt16>(holdVerifier.ID, holdVerifier);
				//ListDictionary lidMetaName = pool.LidMetaName;
				////this is the message
				//HoldString holdMsg = new HoldString( ref lidMetaName)
				//{
				//  ID=1,
				//  MetaName = "msg",
				//  Value = msg,
				//  Title = "title" 
				//};
				//pool.AddItem<HoldString>(holdMsg.ID, holdMsg);
				//HoldString holdmmsg = new HoldString(ref lidMetaName)
				//{
				//  ID=2,
				//  MetaName = "mmsg",
				//  Value = "mmsg" , 
				//  Title = "title" 
				//};
				#endregion AddHolders
				//Utils.Debugger.DebugListDictionary(ref msg, "domainName", ref lidMetaName);
				//get the value be metaName
				logger.Info ( "I queried the pool by property with meta Value and value user_name " );
				HolderForStrings HolderForStrings = pool.GetItemByPropertyValue<HolderForStrings> ( "MetaName", "hfs1" );
				//logger.Info ( "object dump" + Utils.Log.ObjDumper.DumpObject ( HolderForStrings ) );
				logger.Info ( "I found the following value for property with the name \"Name\" " );
				logger.Info ( HolderForStrings.MetaName);
				Console.ReadLine ();
				
			} //eof Main
		} //eof class 
		public class Animal
		{
			public Int32 ID { get; set; }
			public String Name { get; set; }
		}
		public class HolderForStrings
		{
			public Int32 ID { get; set; }
			public String Value { get; set; }
			public String MetaName { get; set; }
			Type ObjType = typeof ( string );
			public Int32 Size { get; set; }
			public bool IsOptional { get; set; }
			public bool IsPrimaryKey { get; set; }
		} //eof class
		public class Vegetable
		{
			public Int32 Identifier { get; set; }
			public String Color { get; set; }
			public Boolean IsTasty { get; set; }
		}
		public class Mineral
		{
			public Int32 UniqueID { get; set; }
			public Boolean IsPoisonousToAnimal { get; set; }
			public String Name { get; set; } 
		}
		#region classObjectPool
		//public class ObjectPool
		//{
		//  public int Count
		//  {
		//    get { return m_pool.Count; }
		//  }
		//  public ObjectPool ()
		//  {
		//    m_pool = new Dictionary<Type, Dictionary<Int32, Object>> ();
		//  }
		//  private Dictionary<Type, Dictionary<Int32, Object>> m_pool;
		//  public void AddItem<T> ( Int32 pID, T value )
		//  {
		//    Type myType = typeof ( T );
		//    if (!m_pool.ContainsKey ( myType ))
		//    {
		//      m_pool.Add ( myType, new Dictionary<int, object> () );
		//      m_pool[myType].Add ( pID, value );
		//      return;
		//    }
		//    if (!m_pool[myType].ContainsKey ( pID ))
		//    {
		//      m_pool[myType].Add ( pID, value );
		//      return;
		//    }
		//    m_pool[myType][pID] = value;
		//  }
		//  public bool RemoveItem<T> ( Int32 pID )
		//  {
		//    Type myType = typeof ( T );
		//    if (!m_pool.ContainsKey ( myType ))
		//      return false;
		//    if (!m_pool[myType].ContainsKey ( pID ))
		//      return false;
		//    return m_pool[myType].Remove ( pID );
		//  }
		//  public bool ContainsKey<T> ( Int32 pID )
		//  {
		//    Type myType = typeof ( T );
		//    if (!m_pool.ContainsKey ( myType ))
		//      return false;
		//    if (!m_pool[myType].ContainsKey ( pID ))
		//      return false;
		//    return m_pool[myType].ContainsKey ( pID );
		//  }
		//  public IEnumerable<T> GetItems<T> ()
		//  {
		//    Type myType = typeof ( T );
		//    if (!m_pool.ContainsKey ( myType ))
		//      return new T[0];
		//    return m_pool[myType].Values as IEnumerable<T>;
		//  }
		//  /// <summary>
		//  /// Gets the item.
		//  /// </summary>
		//  /// <typeparam name="T"></typeparam>
		//  /// <param name="pID">The p ID.</param>
		//  /// <returns></returns>
		//  /// <exception cref="KeyNotFoundException"></exception>
		//  public T GetItem<T> ( Int32 pID )
		//  {
		//    // will throw KeyNotFoundException if either of the dictionaries 
		//    // does not hold the required key
		//    return (T)m_pool[typeof ( T )][pID];
		//  }
		//} //eof pool  
		#endregion
		public enum EnumType : byte
		{
			String,
			Int32,
			Boolean
		}
	} //eof program  
