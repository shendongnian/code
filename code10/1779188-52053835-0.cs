    namespace WindowsFormsApp1
    {
        public class m_genders
        {
            public int id;
            public string title;
        }
    
        public class m_employees
        {
            public int employeeid { get; set; }
            public int genderid { get; set; }
            public string lastname { get; set; }
            
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                List<m_genders> genders = new List<m_genders>
                {
                    new m_genders {id = 1, title = "Male"},
                    new m_genders {id = 2, title = "Female"}
                };
    
                List<m_employees> Items = new List<m_employees>
                {
                    new m_employees{ employeeid = 1, lastname = "mike", genderid = 1 },
                    new m_employees{ employeeid = 2, lastname = "jeni", genderid = 2 }
                };
    
    
                var x = from emp in Items
                    join sex in genders
                        on emp.genderid equals sex.id
                        into a
                    from b in a.DefaultIfEmpty(new m_genders())
                    select new
                    {
                        emp.lastname,
                        emp.genderid,
                        sex = b.title
                    };
            }
        }
    }
