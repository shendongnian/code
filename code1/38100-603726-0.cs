    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.dataGridView1.AllowUserToResizeRows = false;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.BackgroundColor = SystemColors.Window;
                this.dataGridView1.BorderStyle = BorderStyle.None;
                this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.ColumnHeadersVisible = false;
                this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                this.dataGridView1.MultiSelect = false;
                this.dataGridView1.RowHeadersVisible = false;
                this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
    
                dataGridView1.DataSource = Directory.GetFiles(Environment.CurrentDirectory).Select(f => new FileEdit { FileName = Path.GetFileName(f) }).ToList();
            }
    
            private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
                dataGridView1.BeginEdit(true);
            }
    
        }
    
        class FileEdit
        {
            public string FileName { get; set; }    
        }
    }
