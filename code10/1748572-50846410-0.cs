    using System.Runtime.CompilerServices;
    public static void Main( string[] args )
    {
        object a = null;
        object b = null;
        Console.WriteLine( AreSame( ref a, ref b ) ); // Prints False
        Console.WriteLine( AreSame( ref a, ref a ) ); // Prints True
    }
    unsafe static bool AreSame<T>( ref T a, ref T b )
    {
        var pA = Unsafe.AsPointer( ref a );
        var pB = Unsafe.AsPointer( ref b );
        return pA == pB;
    }
