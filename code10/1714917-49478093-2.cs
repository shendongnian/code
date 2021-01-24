     public class Employees
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
      ///create an array
     ArrayList myData = new ArrayList();
     ///Now,let ur datareader do the job for you .
     while (reader.Read())
               {
                   Employees emp = new Employees();
                   emp.Id = (int)reader[0];
                   emp.Name = reader[1].ToString();
                   emp.Age = (int)reader[2];
                   myData.Add(m);
               }
               dataGridView1.DataSource = myData;
