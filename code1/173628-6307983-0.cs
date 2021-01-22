						var pi = entity.GetType( ).GetProperty( eleProperty.Name.LocalName );
						if ( pi.PropertyType == typeof( DateTime ) )
						{
							DateTime val = DateTime.MinValue;
							DateTime.TryParse( ele.Value, out val );
							pi.SetValue( entity, val, null );
						}
						else if ( pi.PropertyType == typeof( Int32 ) )
						{
							int val = 0;
							Int32.TryParse( eleProperty.Value, out val );
							pi.SetValue( entity, val, null );
						}
						else if ( pi.PropertyType == typeof( bool ) )
						{
							bool val = false;
							Boolean.TryParse( eleProperty.Value, out val );
							pi.SetValue( entity, val, null );
						}
						else
						{
							pi.SetValue( entity, eleProperty.Value, null );
						}
