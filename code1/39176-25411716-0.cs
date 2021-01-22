            if (destination is IEnumerable && source is IEnumerable)
            {
                var dest_enumerator = (destination as IEnumerable).GetEnumerator();
                var src_enumerator = (source as IEnumerable).GetEnumerator();
                while (dest_enumerator.MoveNext() && src_enumerator.MoveNext())
                    dest_enumerator.Current.Assign(src_enumerator.Current);
            }
            else
            {
                var destProperties = destination.GetType().GetProperties();
                foreach (var sourceProperty in source.GetType().GetProperties())
                {
                    foreach (var destProperty in destProperties)
                    {
                        if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            destProperty.SetValue(destination,     sourceProperty.GetValue(source, new object[] { }), new object[] { });
                            break;
                        }
                    }
                }
            }
