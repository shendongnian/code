        public static void CopyPropertyValues( this object destination, object source )
        {
            if ( !( destination.GetType ().Equals ( source.GetType () ) ) )
                throw new ArgumentException ( "Type mismatch" );
            if ( destination is IEnumerable )
            {
                var dest_enumerator = (destination as IEnumerable).GetEnumerator();
                var src_enumerator = (source as IEnumerable).GetEnumerator();
                while ( dest_enumerator.MoveNext () && src_enumerator.MoveNext () )
                    dest_enumerator.Current.CopyPropertyValues ( src_enumerator.Current );
            }
            else
            {
                var destProperties = destination.GetType ().GetRuntimeProperties ();
                foreach ( var sourceProperty in source.GetType ().GetRuntimeProperties () )
                {
                    foreach ( var destProperty in destProperties )
                    {
                        if ( destProperty.Name == sourceProperty.Name 
                            && destProperty.PropertyType.GetTypeInfo ()
                                .IsAssignableFrom ( sourceProperty.PropertyType.GetTypeInfo () ) )
                        {
                            destProperty.SetValue ( destination, sourceProperty.GetValue (
                                source, new object[] { } ), new object[] { } );
                            break;
                        }
                    }
                }
            }
        }
