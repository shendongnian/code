    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.IO;
    
    namespace CSVImport
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                using (SQLiteConnection con = new SQLiteConnection("data source=data.db3"))
                {
                    if (!File.Exists("data.db3"))
                    {
                        con.Open();
                        using (SQLiteCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandText =
                                @"
                            CREATE TABLE [Import] (
                                [RowId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                [FeatType] varchar,
                                [FeatName] varchar,
                                [Value] varchar,
                                [Actual] decimal,
                                [Nominal] decimal,
                                [Dev] decimal,
                                [TolMin] decimal,
                                [TolPlus] decimal,
                                [OutOfTol] decimal,
                                [Comment] nvarchar);";
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
    
                    con.Open();
    
                    using (SQLiteCommand insertCommand = con.CreateCommand())
                    {
                        insertCommand.CommandText =
                            @"
                        INSERT INTO Import 	(FeatType, FeatName, Value, Actual, Nominal, Dev, TolMin, TolPlus, OutOfTol, Comment)
                        VALUES     (@FeatType, @FeatName, @Value, @Actual, @Nominal, @Dev, @TolMin, @TolPlus, @OutOfTol, @Comment);";
    
                        insertCommand.Parameters.Add(new SQLiteParameter("@FeatType", DbType.String));
                        insertCommand.Parameters.Add(new SQLiteParameter("@FeatName", DbType.String));
                        insertCommand.Parameters.Add(new SQLiteParameter("@Value", DbType.String));
                        insertCommand.Parameters.Add(new SQLiteParameter("@Actual", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@Nominal", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@Dev", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@TolMin", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@TolPlus", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@OutOfTol", DbType.Decimal));
                        insertCommand.Parameters.Add(new SQLiteParameter("@Comment", DbType.String));
    
                        string[] files = Directory.GetFiles(Environment.CurrentDirectory, "TextFile*.*");
    
                        foreach (string file in files)
                        {
                            string[] lines = File.ReadAllLines(file);
                            bool parse = false;
    
                            foreach (string tmpLine in lines)
                            {
                                string line = tmpLine.Trim();
                                if (!parse && line.StartsWith("Feat. Type,"))
                                {
                                    parse = true;
                                    continue;
                                }
                                if (!parse || string.IsNullOrEmpty(line))
                                {
                                    continue;
                                }
    
    
                                foreach (SQLiteParameter parameter in insertCommand.Parameters)
                                {
                                    parameter.Value = null;
                                }
    
                                string[] values = line.Split(new[] {','});
    
                                for (int i = 0; i < values.Length - 1; i++)
                                {
                                    SQLiteParameter param = insertCommand.Parameters[i];
                                    if (param.DbType == DbType.Decimal)
                                    {
                                        decimal value;
                                        param.Value = decimal.TryParse(values[i], out value) ? value : 0;
                                    }
                                    else
                                    {
                                        param.Value = values[i];
                                    }
                                }
    
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
    }
