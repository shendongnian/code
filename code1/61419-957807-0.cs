	/// <summary>
	/// Utility class for comparing objects.
	/// </summary>
	public static class ObjectComparer
	{
		/// <summary>
		/// Compares the public properties of any 2 objects and determines if the properties of each
		/// all contain the same value.
		/// <para> 
		/// In cases where object1 and object2 are of different Types (both being derived from Type T) 
		/// we will cast both objects down to the base Type T to ensure the property comparison is only 
		/// completed on COMMON properties.
		/// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
		/// both objects will be cast to Foo for comparison)
		/// </para>
		/// </summary>
		/// <typeparam name="T">Any class with public properties.</typeparam>
		/// <param name="object1">Object to compare to object2.</param>
		/// <param name="object2">Object to compare to object1.</param>
		/// <param name="propertyInfoList">A List of <see cref="PropertyInfo"/> objects that contain data on the properties
		/// from object1 that are not equal to the corresponding properties of object2.</param>
		/// <returns>A boolean value indicating whether or not the properties of each object match.</returns>
		public static bool GetDifferentProperties<T> ( T object1 , T object2 , out List<PropertyInfo> propertyInfoList )
			where T : class
		{
			return GetDifferentProperties<T>( object1 , object2 , null , out propertyInfoList );
		}
		/// <summary>
		/// Compares the public properties of any 2 objects and determines if the properties of each
		/// all contain the same value.
		/// <para> 
		/// In cases where object1 and object2 are of different Types (both being derived from Type T) 
		/// we will cast both objects down to the base Type T to ensure the property comparison is only 
		/// completed on COMMON properties.
		/// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
		/// both objects will be cast to Foo for comparison)
		/// </para>
		/// </summary>
		/// <typeparam name="T">Any class with public properties.</typeparam>
		/// <param name="object1">Object to compare to object2.</param>
		/// <param name="object2">Object to compare to object1.</param>
		/// <param name="ignoredProperties">A list of <see cref="PropertyInfo"/> objects
		/// to ignore when completing the comparison.</param>
		/// <param name="propertyInfoList">A List of <see cref="PropertyInfo"/> objects that contain data on the properties
		/// from object1 that are not equal to the corresponding properties of object2.</param>
		/// <returns>A boolean value indicating whether or not the properties of each object match.</returns>
		public static bool GetDifferentProperties<T> ( T object1 , T object2 , List<PropertyInfo> ignoredProperties , out List<PropertyInfo> propertyInfoList )
			where T : class
		{
			propertyInfoList = new List<PropertyInfo>();
			// If either object is null, we can't compare anything
			if ( object1 == null || object2 == null )
			{
				return false;
			}
			Type object1Type = object1.GetType();
			Type object2Type = object2.GetType();
			// In cases where object1 and object2 are of different Types (both being derived from Type T) 
			// we will cast both objects down to the base Type T to ensure the property comparison is only 
			// completed on COMMON properties.
			// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
			// both objects will be cast to Foo for comparison)
			if ( object1Type != object2Type )
			{
				object1Type = typeof ( T );
				object2Type = typeof ( T );
			}
			// Remove any properties to be ignored
			List<PropertyInfo> comparisonProps =
				RemoveProperties( object1Type.GetProperties() , ignoredProperties );
			foreach ( PropertyInfo object1Prop in comparisonProps )
			{
				Type propertyType = null;
				object object1PropValue = null;
				object object2PropValue = null;
				// Rule out an attempt to check against a property which requires
				// an index, such as one accessed via this[]
				if ( object1Prop.GetIndexParameters().GetLength( 0 ) == 0 )
				{
					// Get the value of each property
					object1PropValue = object1Prop.GetValue( object1 , null );
					object2PropValue = object2Type.GetProperty( object1Prop.Name ).GetValue( object2 , null );
					// As we are comparing 2 objects of the same type we know
					// that they both have the same properties, so grab the
					// first non-null value
					if ( object1PropValue != null )
						propertyType = object1PropValue.GetType().GetInterface( "IComparable" );
					if ( propertyType == null )
						if ( object2PropValue != null )
							propertyType = object2PropValue.GetType().GetInterface( "IComparable" );
				}
				// If both objects have null values or were indexed properties, don't continue
				if ( propertyType != null )
				{
					// If one property value is null and the other is not null, 
					// they aren't equal; this is done here as a native CompareTo
					// won't work with a null value as the target
					if ( object1PropValue == null || object2PropValue == null )
					{
						propertyInfoList.Add( object1Prop );
					}
					else
					{
						// Use the native CompareTo method
						MethodInfo nativeCompare = propertyType.GetMethod( "CompareTo" );
						// Sanity Check:
						// If we don't have a native CompareTo OR both values are null, we can't compare;
						// hence, we can't confirm the values differ... just go to the next property
						if ( nativeCompare != null )
						{
							// Return the native CompareTo result
							bool equal = ( 0 == (int) ( nativeCompare.Invoke( object1PropValue , new object[] {object2PropValue} ) ) );
							if ( !equal )
							{
								propertyInfoList.Add( object1Prop );
							}
						}
					}
				}
			}
			return propertyInfoList.Count == 0;
		}
		/// <summary>
		/// Compares the public properties of any 2 objects and determines if the properties of each
		/// all contain the same value.
		/// <para> 
		/// In cases where object1 and object2 are of different Types (both being derived from Type T) 
		/// we will cast both objects down to the base Type T to ensure the property comparison is only 
		/// completed on COMMON properties.
		/// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
		/// both objects will be cast to Foo for comparison)
		/// </para>
		/// </summary>
		/// <typeparam name="T">Any class with public properties.</typeparam>
		/// <param name="object1">Object to compare to object2.</param>
		/// <param name="object2">Object to compare to object1.</param>
		/// <returns>A boolean value indicating whether or not the properties of each object match.</returns>
		public static bool HasSamePropertyValues<T> ( T object1 , T object2 )
			where T : class
		{
			return HasSamePropertyValues<T>( object1 , object2 , null );
		}
		/// <summary>
		/// Compares the public properties of any 2 objects and determines if the properties of each
		/// all contain the same value.
		/// <para> 
		/// In cases where object1 and object2 are of different Types (both being derived from Type T) 
		/// we will cast both objects down to the base Type T to ensure the property comparison is only 
		/// completed on COMMON properties.
		/// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
		/// both objects will be cast to Foo for comparison)
		/// </para>
		/// </summary>
		/// <typeparam name="T">Any class with public properties.</typeparam>
		/// <param name="object1">Object to compare to object2.</param>
		/// <param name="object2">Object to compare to object1.</param>
		/// <param name="ignoredProperties">A list of <see cref="PropertyInfo"/> objects
		/// to ignore when completing the comparison.</param>
		/// <returns>A boolean value indicating whether or not the properties of each object match.</returns>
		public static bool HasSamePropertyValues<T> ( T object1 , T object2 , List<PropertyInfo> ignoredProperties )
			where T : class
		{
			// If either object is null, we can't compare anything
			if ( object1 == null || object2 == null )
			{
				return false;
			}
			Type object1Type = object1.GetType();
			Type object2Type = object2.GetType();
			// In cases where object1 and object2 are of different Types (both being derived from Type T) 
			// we will cast both objects down to the base Type T to ensure the property comparison is only 
			// completed on COMMON properties.
			// (ex. Type T is Foo, object1 is GoodFoo and object2 is BadFoo -- both being inherited from Foo --
			// both objects will be cast to Foo for comparison)
			if ( object1Type != object2Type )
			{
				object1Type = typeof ( T );
				object2Type = typeof ( T );
			}
			// Remove any properties to be ignored
			List<PropertyInfo> comparisonProps =
				RemoveProperties( object1Type.GetProperties() , ignoredProperties );
			foreach ( PropertyInfo object1Prop in comparisonProps )
			{
				Type propertyType = null;
				object object1PropValue = null;
				object object2PropValue = null;
				// Rule out an attempt to check against a property which requires
				// an index, such as one accessed via this[]
				if ( object1Prop.GetIndexParameters().GetLength( 0 ) == 0 )
				{
					// Get the value of each property
					object1PropValue = object1Prop.GetValue( object1 , null );
					object2PropValue = object2Type.GetProperty( object1Prop.Name ).GetValue( object2 , null );
					// As we are comparing 2 objects of the same type we know
					// that they both have the same properties, so grab the
					// first non-null value
					if ( object1PropValue != null )
						propertyType = object1PropValue.GetType().GetInterface( "IComparable" );
					if ( propertyType == null )
						if ( object2PropValue != null )
							propertyType = object2PropValue.GetType().GetInterface( "IComparable" );
				}
				// If both objects have null values or were indexed properties, don't continue
				if ( propertyType != null )
				{
					// If one property value is null and the other is not null, 
					// they aren't equal; this is done here as a native CompareTo
					// won't work with a null value as the target
					if ( object1PropValue == null || object2PropValue == null )
					{
						return false;
					}
					// Use the native CompareTo method
					MethodInfo nativeCompare = propertyType.GetMethod( "CompareTo" );
					// Sanity Check:
					// If we don't have a native CompareTo OR both values are null, we can't compare;
					// hence, we can't confirm the values differ... just go to the next property
					if ( nativeCompare != null )
					{
						// Return the native CompareTo result
						bool equal = ( 0 == (int) ( nativeCompare.Invoke( object1PropValue , new object[] {object2PropValue} ) ) );
						if ( !equal )
						{
							return false;
						}
					}
				}
			}
			return true;
		}
		/// <summary>
		/// Removes any <see cref="PropertyInfo"/> object in the supplied List of 
		/// properties from the supplied Array of properties.
		/// </summary>
		/// <param name="allProperties">Array containing master list of 
		/// <see cref="PropertyInfo"/> objects.</param>
		/// <param name="propertiesToRemove">List of <see cref="PropertyInfo"/> objects to
		/// remove from the supplied array of properties.</param>
		/// <returns>A List of <see cref="PropertyInfo"/> objects.</returns>
		private static List<PropertyInfo> RemoveProperties (
			IEnumerable<PropertyInfo> allProperties , IEnumerable<PropertyInfo> propertiesToRemove )
		{
			List<PropertyInfo> innerPropertyList = new List<PropertyInfo>();
			// Add all properties to a list for easy manipulation
			foreach ( PropertyInfo prop in allProperties )
			{
				innerPropertyList.Add( prop );
			}
			// Sanity check
			if ( propertiesToRemove != null )
			{
				// Iterate through the properties to ignore and remove them from the list of 
				// all properties, if they exist
				foreach ( PropertyInfo ignoredProp in propertiesToRemove )
				{
					if ( innerPropertyList.Contains( ignoredProp ) )
					{
						innerPropertyList.Remove( ignoredProp );
					}
				}
			}
			return innerPropertyList;
		}
	}
