		public static string GetEnumDescription ( Object value )
		{
			try
			{
				Type objType = value.GetType();
				FieldInfo fldInf = objType.GetField( Enum.GetName( objType, value ) );
				Object[ ] attributes = fldInf.GetCustomAttributes( false );
				if ( attributes.Length > 0 )
				{
					DescriptionAttribute descAttr = ( DescriptionAttribute )attributes[ 0 ];
					return descAttr.Description;
				}
				else
				{
					return value.ToString();
				}
			}
			catch
			{
				return string.Empty;
			}
		}
