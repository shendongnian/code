    public static bool AreEquivalentArray( char[] a, char[] b )
            {
                if (a.Length != b.Length)
                    return false;
    
                Array.Sort(a);
                Array.Sort(b);
                for (int i = 0; i < a.Length; i++)
                {
                    if( !a[i].Equals( b[i] ) )
                        return false;
                }
                return true;
            }
