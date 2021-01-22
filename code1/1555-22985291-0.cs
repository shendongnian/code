            SqlCommand cmd = new SqlCommand( "Select * from Employee",con);
            SqlDataReader dr = cmd.ExecuteReader( );
            DataTable dt = new DataTable( "Employee" );
            dt.Load( dr );
            var Data = dt.AsEnumerable( );
            var names = from emp in Data
                        select emp.Field<String>( dt.Columns[1] );
            foreach( var name in names )
            {
                Console.WriteLine( name );
            }
