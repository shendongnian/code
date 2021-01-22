    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Text;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            public const int AW_ACTIVATE = 0x00020000;
            public const int AW_HIDE = 0x00010000;
            public const int AW_HOR_NEGATIVE = 0x00000002;
            public const int AW_HOR_POSITIVE = 0x00000001;
            public const int AW_SLIDE = 0x00040000;
    
            [DllImport("user32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AnimateWindow(IntPtr hWnd, int time, int awFlags);
            
            [STAThread]
            public static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    
        public class Form1 : Form
        {
            public Form form;
    
            public Form1()
            {
                InitializeComponent();
                form = new Form2();
                form.Show();
                form.Hide();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                form.Location = new Point(Location.X, Location.Y + form.Height + 100);
                Program.AnimateWindow(form.Handle, 1000, Program.AW_SLIDE | Program.AW_HOR_NEGATIVE | Program.AW_ACTIVATE);
                form.Show();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Program.AnimateWindow(form.Handle, 1000, Program.AW_HIDE | Program.AW_HOR_POSITIVE);
                form.Hide();
            }
    
            #region Windows Form Designer generated code
    
            private void InitializeComponent()
            {
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.Location = new System.Drawing.Point(11, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(133, 114);
                this.button1.TabIndex = 0;
                this.button1.Text = "SHOW";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.Location = new System.Drawing.Point(150, 12);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(133, 114);
                this.button2.TabIndex = 1;
                this.button2.Text = "HIDE";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(294, 138);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "Form1";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Form1";
                this.ResumeLayout(false);
            }
    
            #endregion
    
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
        }
    
        public class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                this.richTextBox1.VisibleChanged += new EventHandler(richTextBox1_VisibleChanged);
            }
    
            void richTextBox1_VisibleChanged(object sender, EventArgs e)
            {
                if (this.richTextBox1.Visible)
                {
                    System.Diagnostics.Debug.WriteLine("Visible!");
                    this.richTextBox1.Capture = true;
                    this.richTextBox1.Update();
                    this.richTextBox1.Capture = false;
                    this.richTextBox1.Refresh();
                }
                else System.Diagnostics.Debug.WriteLine("InVisible!");
            }
    
            #region Windows Form Designer generated code
    
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
                this.richTextBox1 = new System.Windows.Forms.RichTextBox();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
                this.richTextBox1.Location = new System.Drawing.Point(0, 0);
                this.richTextBox1.Name = "richTextBox1";
                this.richTextBox1.Size = new System.Drawing.Size(240, 50);
                this.richTextBox1.TabIndex = 0;
                this.richTextBox1.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
                this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.textBox1.Location = new System.Drawing.Point(0, 57);
                this.textBox1.Multiline = true;
                this.textBox1.Name = "textBox1";
                this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.textBox1.Size = new System.Drawing.Size(240, 50);
                this.textBox1.TabIndex = 1;
                this.textBox1.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(240, 107);
                this.ControlBox = false;
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.richTextBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Name = "Form2";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Form2";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
    
            #endregion
    
            protected override void OnActivated(EventArgs e)
            {
                base.OnActivated(e);
                System.Diagnostics.Debug.WriteLine("OnActivated");
                this.Refresh();
            }
    
            private System.Windows.Forms.RichTextBox richTextBox1;
            private System.Windows.Forms.TextBox textBox1;
        }
    }
