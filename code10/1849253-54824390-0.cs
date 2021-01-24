        static class CheckedListBoxExtension {
            public static bool ContainsSet(this WinForms.CheckedListBox cbl, ICollection<int> values)
            {
                var valueSet = new HashSet<int>( values );
    
                foreach(int index in cbl.CheckedIndices) {
                    if ( valueSet.Contains( index ) ) {
                        valueSet.Remove( index );
                        
                    }
                }
    
                return valueSet.Count == 0;
            }
        }
