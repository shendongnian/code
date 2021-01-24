    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
    { 
        while (rdr.Read())
        {
            string fn = rdr.GetString(0);
            using (var rs = rdr.GetStream(1))
            {
                var fileName = $"c:\\temp\\{fn}.txt";
                using (var fs = File.OpenWrite(fileName))
                {
                    rs.CopyTo(fs);
                }
                Console.WriteLine(fileName);
    
            }
        }                
    }
