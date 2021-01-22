    namespace MyNamespace
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.Common;
        using System.Data.SqlClient;
        using System.Globalization;
        using System.Threading;
        public sealed class MyProgram
        {
            private DbConnectionStringBuilder connectionStringBuilder;
            public static void Main(string[] args)
            {
                DbConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(args[0]);
                MyProgram myProgram = new MyProgram(connectionStringBuilder);
                myProgram.Run();
            }
            public MyProgram(DbConnectionStringBuilder connectionStringBuilder)
            {
                if (null == connectionStringBuilder)
                {
                    throw new ArgumentNullException("connectionStringBuilder");
                }
                this.connectionStringBuilder = connectionStringBuilder;
            }
            public void Run()
            {
                IList<Guid> guids = new List<Guid>(2);
                guids.Add(this.Create(DateTime.Now));
                Thread.Sleep(new TimeSpan(0, 0, 5)); // I just want to assure there is a different time in the next row. :)
                guids.Add(this.Create(DateTime.UtcNow));
                foreach(Guid guid in guids)
                {
                    Console.WriteLine(this.Retrieve(guid));
                }
            }
            private Guid Create(DateTime dateTime)
            {
                Guid result = Guid.Empty;
                if (dateTime.Kind == DateTimeKind.Unspecified)
                {
                    throw new ArgumentException("I cannot work with unspecified DateTimeKinds.", "dateTime");
                }
                else if (dateTime.Kind == DateTimeKind.Local)
                {
                    dateTime = dateTime.ToUniversalTime();
                }
                using (IDbConnection connection = new SqlConnection(this.connectionStringBuilder.ConnectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO MyTable (MyUtcDate) OUTPUT INSERTED.Id VALUES (@DateTime)";
                        IDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "DateTime";
                        parameter.Value = dateTime;
                        command.Parameters.Add(parameter);
                        command.Connection.Open();
                        result = (Guid)command.ExecuteScalar();
                    }
                }
                return result;
            }
            private string Retrieve(Guid id)
            {
                string result = string.Empty;
                using (IDbConnection connection = new SqlConnection(this.connectionStringBuilder.ConnectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT MyUtcDate FROM MyTable WHERE Id = @Id";
                        IDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "Id";
                        parameter.Value = id;
                        command.Parameters.Add(parameter);
                        command.Connection.Open();
                        using (IDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (dataReader.Read())
                            {
                                DateTime myDate = DateTime.SpecifyKind(dataReader.GetDateTime(dataReader.GetOrdinal("myUtcDate")), DateTimeKind.Utc);
                                result = string.Format(CultureInfo.CurrentCulture, "{0}: {1}, {2}: {3}", TimeZoneInfo.Utc.StandardName, myDate, TimeZoneInfo.Local.StandardName, myDate.ToLocalTime());
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
