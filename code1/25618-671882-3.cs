    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    namespace ConsoleApplication1
    {
        class Program
    
        {
            
            
            
    
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome ...!");
                String conString = "SERVER = localhost; DATABASE = l2emu; User ID = root; PASSWORD = password;";
           
            MySqlConnection  connection = new MySqlConnection(conString);
                
                String command = "SELECT * FROM characters";
              MySqlCommand  cmd = new MySqlCommand(command,connection);
    MySqlDataReader reader;
    try
    {
        connection.Open();
        cmd.ExecuteNonQuery();
        reader = cmd.ExecuteReader();
        cmd.CommandType = System.Data.CommandType.Text;
        while (reader.Read() != false)
        {
            
            Console.WriteLine(reader["char_name"]);
            Console.WriteLine(reader["level"]);
    
        }
    
        Console.ReadLine();
    
    }
    catch (MySqlException MySqlError)
    {
        Console.WriteLine(MySqlError.Message);
    }
                
            }
        }
    }
