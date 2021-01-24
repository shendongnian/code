    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            PopulateGrid();
        }
    
        private ArrayList myList = new ArrayList();
        private List<Student> students = new List<Student>();
    
        private void PopulateGrid()
        {
            students = new List<Student>
            {
                new Student {Lastname = "aa"},
                new Student {Lastname = "bb"},
                new Student {Lastname = "cc"},
                new Student {Lastname = "cc"},
                new Student {Lastname = "cc"},
                new Student {Lastname = "ee"},
                new Student {Lastname = "ff"},
                new Student {Lastname = "ff"},
                new Student {Lastname = "gg"},
                new Student {Lastname = "gg"},
            };
    
            dataGridView2.DataSource = students;
            myList = new ArrayList(students.Select(x => x.Lastname).ToList());
        }
    
        public class Student
        {
            public string Lastname { get; set; }
        }
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var index = myList.BinarySearch(textBoxBinarySearch.Text);
            if(index > -1)
            {
                dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dataGridView2.Rows[index].Selected = true;
                dataGridView2.CurrentCell = dataGridView2.Rows[index].Cells[0];
                MessageBox.Show("Index is equal to: " + index, "Binary Search");
            }
        }
    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
    
                var selected = dataGridView2.SelectedRows[0];
                students.RemoveAt(selected.Index);
    
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = students;
                myList = new ArrayList(students.Select(x => x.Lastname).ToList());
            }
        }
    }
