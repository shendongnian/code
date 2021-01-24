    ''It is better to create a class to handle your data :)
      public class MyData
    {
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
           } 
        }
      ''Ever heard of ArrayList...It's amazing :)
      ArrayList myarray= new ArrayList();
      '''Now let's fix the main issue :)
      SqlDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
      MyData data = new MyData();
      data.Id = (int)reader[0];
      data.Name = reader[1].ToString();
      data.Age = (int)reader[2];
      myArray.Add(data);
      }
      myDataGrid.DataSource = sequence;
