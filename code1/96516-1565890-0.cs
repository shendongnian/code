    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    public class Person {
        public string Name { get; set; }
    
        [STAThread]
        static void Main() {
            var people = new List<Person> { new Person { Name = "Fred" } };
            BindingSource bs = new BindingSource();
            bs.DataSource = people;
            
            Application.Run(new Form { Controls = { new DataGridView {
                Dock = DockStyle.Fill, DataSource = bs } } });
        }
    }
