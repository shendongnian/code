	public class DualKeyDictionary<TKey1, TKey2, TValue> : Dictionary<TKey1, Dictionary<TKey2, TValue>> , IDictionary< object[], TValue >
	{
		#region IDictionary<object[],TValue> Members
	
		void IDictionary<object[], TValue>.Add( object[] key, TValue value )
		{
			if ( key == null || key.Length != 2 )
				throw new ArgumentException( "Invalid Key" );
	
			TKey1 key1 = key[0] as TKey1;
			TKey2 key2 = key[1] as TKey2;
	
			if ( !ContainsKey( key1 ) )
				Add( key1, new Dictionary<TKey2, TValue>() );
	
			this[key1][key2] = value;
		}
	
		bool IDictionary<object[], TValue>.ContainsKey( object[] key )
		{
			if ( key == null || key.Length != 2 )
				throw new ArgumentException( "Invalid Key" );
	
			TKey1 key1 = key[0] as TKey1;
			TKey2 key2 = key[1] as TKey2;
	
			if ( !ContainsKey( key1 ) )
				return false;
	
			if ( !this[key1].ContainsKey( key2 ) )
				return false;
	
			return true;
		}
