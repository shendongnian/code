    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Enter element at 0,0:" );
            string m00 = Console.ReadLine();
            Console.WriteLine( "Enter element at 0,1:" );
            string m01 = Console.ReadLine();
            Console.WriteLine( "Enter element at 1,0:" );
            string m10 = Console.ReadLine();
            Console.WriteLine( "Enter element at 1,1:" );
            string m11 = Console.ReadLine();
            int[,] inputMatrix = new int[ 2, 2 ];
            inputMatrix[ 0, 0 ] = int.Parse( m00 );
            inputMatrix[ 0, 1 ] = int.Parse( m01 );
            inputMatrix[ 1, 0 ] = int.Parse( m10 );
            inputMatrix[ 1, 1 ] = int.Parse( m11 );
        }
    }
}
