    public class Sample
    {
        public string val1{ get; set; }
        public int val2 { get; set; }
        //Add other fields for data as per ur database
       
        public Sample(string val1,int val2 )//add further members in constructor
        {
           this.val1 = val1;
           this.val2 = val2;
        }
    }
    Sample[] allRecords = null;
    List<Sample> list = new List<Sample>();
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
           list.Add(new Sample(reader.GetString(0), reader.GetInt32(1));
        }
        allRecords = list.ToArray();
    }
