    public partial class Form1 : Form
    {
        List<dummy> Origlist = new List<dummy> {
            new dummy { pk = 1 ,  istype1 = true,  istype2  = false, istype3=false, istype4=false },
            new dummy { pk = 2 ,  istype1 = true,  istype2 = false,  istype3=false, istype4=false },
            new dummy { pk = 3 ,  istype1 = false, istype2 = true,   istype3=false, istype4=false },
            new dummy { pk = 4 ,  istype1 = false, istype2 = true,   istype3=false, istype4=false },
            new dummy { pk = 5 ,  istype1 = false, istype2 = false,  istype3=true,  istype4=false },
            new dummy { pk = 6 ,  istype1 = false, istype2 = false,  istype3=true,  istype4=false },
            new dummy { pk = 7 ,  istype1 = false, istype2 = false,  istype3=false, istype4=true },
            new dummy { pk = 8 ,  istype1 = false, istype2 = false,  istype3=false, istype4=true },
            new dummy { pk = 9 ,  istype1 = false, istype2 = false,  istype3=true,  istype4=false },
            new dummy { pk = 10 , istype1 = false, istype2 = true,   istype3=false, istype4=false },
            new dummy { pk = 11 , istype1 = false, istype2 = false,  istype3=false, istype4=false }
        };
    
        Options options = new Options();
    
        private class Options {
            public bool istype1 { get; set; }
            public bool istype2 { get; set; }
            public bool istype3 { get; set; }
            public bool istype4 { get; set; }
        }
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Bind()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = OrigList.Where(a =>
              (options.istype1 && a.istype1) ||
              (options.istype2 && a.istype2) ||
              (options.istype3 && a.istype3) ||
              (options.istype4 && a.istype4)
            ).ToList();
        }
    
    
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            options.istype1 = checkBox1.checked;
            Bind();
        }
    
    
    
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            options.istype2 = checkBox2.checked;
            Bind();
        }
    
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            options.istype3 = checkBox3.checked;
            Bind();
        }
    
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            options.istype4 = checkBox4.checked;
            Bind();
        }
    
    }
