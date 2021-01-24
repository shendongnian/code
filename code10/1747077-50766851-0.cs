    using System;
    using System.Text;
    public class Triangle
    {
        StringBuilder sb = new StringBuilder( );
    
        public static void Main(string[ ] args)
        {
            Triangle tri = new Triangle( );
                   
            Console.WriteLine(tri.ToString());
            Console.ReadKey( );
        }
        public override string ToString( )
        {
        
            for(int row = 1; row <= 10; ++row)
            {
                for(int col = 1; col <= row; ++col)
                {
                    sb.Append("*");
                }
                sb.Append("\n");
            
            }
            sb.Append("\n");
            for(int row = 10; row >= 1; --row)
            {
                for(int col = 1; col <= row; ++col)
                {
                    sb.Append("*");
                }
                sb.Append("\n");
            }
            sb.Append("\n");
            for(int row = 10; row >= 1; row--) // Outer Loop for number of rows
            {
                for(int col = 1; col <= 10 - row; col++)         //Inner loop for number of spaces
                {
                    sb.Append(" ");
                }
                for(int k = 1; k <= row; k++)  //Secondary inner loop for number of stars
                {
                    sb.Append("*");
                }
                sb.Append("\n");
            }
            sb.Append("\n");
            for(int row = 1; row <= 10; row++)               //Outer Loop for number of rows
            {
                for(int col = 1; col <= 10 - row; col++)         //Inner loop for number of spaces
                {
                    sb.Append(" ");
                }
                for(int k = 1; k <= row; k++)  //Secondary inner loop for number of stars
                {
                    sb.Append("*");
                }
                sb.Append("\n");
            }
            string s = sb.ToString( );
            return s;
        
        }
    
    }
