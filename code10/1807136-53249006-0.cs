    using System.Data.SqlClient;
    
    namespace SqlTransationDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Do your sql logic here 
                DoSomething();
            }
    
            private static bool DoSomething()
            {
                try
                {
                    using (var connection = new SqlConnection("SqlConnectionString"))
                    {
                        connection.Open();
    
                        //If not commited, transaction is rolled-back as soon as it is disposed 
                        using (var transaction = connection.BeginTransaction())
                        {
                            //Either use a false loop to break or throw an exception. Your choise. 
                            do
                            {
                                if (!Foo1(connection, transaction))
                                    break;
                                if (!Foo2(connection, transaction))
                                    break;
                                if (!Foo3(connection, transaction))
                                    break;
    
                                //Commit 
                                transaction.Commit();
                                return true;
                            }
                            while (false);
                        }
                    }
    
                }
                catch
                {
                    return false;
                }
            }
    
            private static bool Foo1(SqlConnection Connection, SqlTransaction Transaction)
            {
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = Connection;
                        command.Transaction = Transaction;
                        command.CommandText = "Query1";
                        command.ExecuteNonQuery();
                    }
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            private static bool Foo2(SqlConnection Connection, SqlTransaction Transaction)
            {
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = Connection;
                        command.Transaction = Transaction;
                        command.CommandText = "Query2";
                        command.ExecuteNonQuery();
                    }
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
            private static bool Foo3(SqlConnection Connection, SqlTransaction Transaction)
            {
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = Connection;
                        command.Transaction = Transaction;
                        command.CommandText = "Query3";
                        command.ExecuteNonQuery();
                    }
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
