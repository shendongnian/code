    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var con = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                using (var cmd = new SQLiteCommand())
                {
    
                    cmd.Connection = con;
                    con.Open();
    
    
                    var cmd1 = @"
                        DROP TABLE IF EXISTS UserInfo;
                        CREATE TABLE IF NOT EXISTS UserInfo(username varchar(255),password 
                                      varchar(255),CONSTRAINT u_username UNIQUE (username));
                        INSERT INTO UserInfo(username,password) VALUES ('mohamed', '12345');
                        ";
                    var cmd2 = @"select count(*) from UserInfo where username = @curent_username
                                    and password = @curent_password;";
                    var cmd3 = @"UPDATE UserInfo SET UserName = @new_username , Password= @new_password
                                where username = @curent_username and password = @curent_password;";
    
    
                    cmd.CommandText = cmd1;
                    cmd.ExecuteNonQuery();
    
                    cmd.CommandText = cmd2;
                    cmd.Parameters.AddWithValue("@curent_username", "mohamed");
                    cmd.Parameters.AddWithValue("@curent_password", "12345");
                    var userCount = (long)cmd.ExecuteScalar();
                    if (userCount == 1)
                    {
                        cmd.CommandText = cmd3;
                        cmd.Parameters.AddWithValue("@new_username", "adam");
                        cmd.Parameters.AddWithValue("@new_password", "6789");
                        var result = (Int32)cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            Console.WriteLine("Username and Password Updated Successfully! | Task Completed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password |Incorrect details entered");
                    }
                }
    
                Console.ReadLine();
            }
    
        }
    }
