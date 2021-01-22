    class Program
    {
        
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome ...!");
            String conString = "SERVER = localhost; DATABASE = l2emu; User ID = root; PASSWORD = password;";
       
        MySqlConnection  connection = new MySqlConnection(conString);
            
            String command = "SELECT * FROM characters";
          MySqlCommand  cmd = new MySqlCommand(command,connection);
