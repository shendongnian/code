    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    namespace CountersListPreview
    {
        internal static class CounterPreview
        {
            [STAThread]
            private static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form f = new CountersListPreviewForm();
                Application.Run(f);
            }
        }
        internal class CountersListPreviewForm : Form
        {
            public CountersListPreviewForm()
            {
                InitializeComponent();
            }
            private PerformanceCounterCategory[] allCats;
            private string[] instances;
            private PerformanceCounter[] counters;
            private PerformanceCounter counter;
            private Timer TitleRefreshTimer;
            private void Form1_Load(object sender, EventArgs e)
            {
                allCats = PerformanceCounterCategory.GetCategories();
                listBox1.DataSource = allCats;
                listBox1.DisplayMember = "CategoryName";
                listBox1.SelectedIndexChanged += On_CatChange;
                listBox2.SelectedIndexChanged += On_InstChange;
                listBox3.SelectedIndexChanged += On_CounterChange;
                textBox2.TextChanged += On_CatFilterChanged;
                textBox3.TextChanged += On_InstFilterChanged;
                textBox4.TextChanged += On_CounterFilterChanged;
                TitleRefreshTimer = new Timer();
                TitleRefreshTimer.Tick += On_Timer;
                TitleRefreshTimer.Interval = 500;
                TitleRefreshTimer.Start();
            }
            private void On_Timer(object sender, EventArgs e)
            {
                textBox1.Text = counter != null ? counter.NextValue().ToString() : "";
            }
            // --------------- SELECTION CHANGE ------------------
            private void On_CatChange(object sender, EventArgs e)
            {
                var cat = listBox1.SelectedItem as PerformanceCounterCategory;
                listBox2.DataSource = instances = cat.GetInstanceNames();
            }
            private void On_InstChange(object sender, EventArgs e)
            {
                var cat = listBox1.SelectedItem as PerformanceCounterCategory;
                var inst = listBox2.SelectedItem as string;
                listBox3.DataSource = counters = cat.GetCounters(inst);
                listBox3.DisplayMember = "CounterName";
            }
            private void On_CounterChange(object sender, EventArgs e)
            {
                counter = listBox3.SelectedItem as PerformanceCounter;
                On_Timer(null, null);
            }
            // --------------- FILTERS ------------------
            private void On_CatFilterChanged(object sender, EventArgs e)
            {
                var filter = textBox2.Text;
                listBox1.DataSource = !string.IsNullOrEmpty(filter) 
                    ? allCats.Where(cat => cat.CategoryName.ToLower().Contains(filter.ToLower())).ToArray() 
                    : allCats;
            }
            private void On_InstFilterChanged(object sender, EventArgs e)
            {
                var filter = textBox3.Text;
                listBox2.DataSource = !string.IsNullOrEmpty(filter) 
                    ? instances.Where(inst => inst.ToLower().Contains(filter.ToLower())).ToArray() 
                    : instances;
            }
            private void On_CounterFilterChanged(object sender, EventArgs e)
            {
                var filter = textBox4.Text;
                listBox3.DataSource = !string.IsNullOrEmpty(filter) 
                    ? counters.Where(c => c.CounterName.ToLower().Contains(filter.ToLower())).ToArray() 
                    : counters;
            }
            // --------------- FORM AND LAYOUT ------------------
            private readonly IContainer components = null;
            protected override void Dispose(bool disposing)
            {
                if (disposing && components != null) components.Dispose();
                base.Dispose(disposing);
            }
            #region Windows Form Designer generated code
            private void InitializeComponent()
            {
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.listBox2 = new System.Windows.Forms.ListBox();
                this.listBox3 = new System.Windows.Forms.ListBox();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.textBox3 = new System.Windows.Forms.TextBox();
                this.textBox4 = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // listBox1
                // 
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(12, 38);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(351, 524);
                this.listBox1.TabIndex = 3;
                // 
                // listBox2
                // 
                this.listBox2.FormattingEnabled = true;
                this.listBox2.Location = new System.Drawing.Point(369, 38);
                this.listBox2.Name = "listBox2";
                this.listBox2.Size = new System.Drawing.Size(351, 524);
                this.listBox2.TabIndex = 3;
                // 
                // listBox3
                // 
                this.listBox3.FormattingEnabled = true;
                this.listBox3.Location = new System.Drawing.Point(726, 38);
                this.listBox3.Name = "listBox3";
                this.listBox3.Size = new System.Drawing.Size(351, 524);
                this.listBox3.TabIndex = 3;
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(726, 568);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(351, 20);
                this.textBox1.TabIndex = 4;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(606, 571);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(114, 13);
                this.label1.TabIndex = 5;
                this.label1.Text = "Counter Value (500ms)";
                // 
                // textBox2
                // 
                this.textBox2.Location = new System.Drawing.Point(12, 12);
                this.textBox2.Name = "textBox2";
                this.textBox2.Size = new System.Drawing.Size(351, 20);
                this.textBox2.TabIndex = 4;
                // 
                // textBox3
                // 
                this.textBox3.Location = new System.Drawing.Point(369, 12);
                this.textBox3.Name = "textBox3";
                this.textBox3.Size = new System.Drawing.Size(351, 20);
                this.textBox3.TabIndex = 4;
                // 
                // textBox4
                // 
                this.textBox4.Location = new System.Drawing.Point(726, 12);
                this.textBox4.Name = "textBox4";
                this.textBox4.Size = new System.Drawing.Size(351, 20);
                this.textBox4.TabIndex = 4;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //this.BackColor = System.Drawing.SystemColors.;
                this.ClientSize = new System.Drawing.Size(1090, 597);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.textBox4);
                this.Controls.Add(this.textBox3);
                this.Controls.Add(this.textBox2);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.listBox3);
                this.Controls.Add(this.listBox2);
                this.Controls.Add(this.listBox1);
                //this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                this.Name = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private ListBox listBox1;
            private ListBox listBox2;
            private ListBox listBox3;
            private TextBox textBox1;
            private Label label1;
            private TextBox textBox2;
            private TextBox textBox3;
            private TextBox textBox4;
        }
    }
