    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Operation System Information" );
            Console.WriteLine( "----------------------------" );
            Console.WriteLine( "Name = {0}", OSInfo.Name );
            Console.WriteLine( "Edition = {0}", OSInfo.Edition );
            Console.WriteLine( "Service Pack = {0}", OSInfo.ServicePack );
            Console.WriteLine( "Version = {0}", OSInfo.VersionString );
            Console.WriteLine( "Bits = {0}", OSInfo.Bits );
            Console.ReadLine();
        }
    }
