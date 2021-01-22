        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //does not sort...
            dataGridView1.DataSource = new List<Person>
            { 
                new Person{ Age=11, Name="Jimmy" },
                new Person{ Age=12, Name="Suzie" }
            };
        }
