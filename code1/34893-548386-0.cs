    foo 1
    bar 2
    baz 3
    ...
    using(StreamReader sr = new StreamReader(File.Open("sourcefile.txt", FileMode.Open)))
    {
      using(SqlConnection conn = new SqlConnection(connectionString))
      {
       conn.Open();
      string line ="";
      while((line = sr.ReadLine()) != "")
      {
         string[] parts = line.split(new string[]{" "}, StringSplitOptions.None);
         string cmdTxt = String.Format("INSERT INTO MyTable(name, value) VALUES('{0}','{1}')", parts[0], parts[1]);
    
          using(SqlCommand cmd = new SqlCommand(cmdTxt, conn))
          {
             cmd.ExecuteNonQuery();
          }
       }
    }
}
