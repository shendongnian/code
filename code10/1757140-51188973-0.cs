    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Scroll(object sender, ScrollEventArgs e)
            {
                this.label1.Text = $"scrollbarHeight: {SystemInformation.HorizontalScrollBarHeight}\n"
                                    + $"verticalScrollPos: {this.VerticalScroll.Value}\n"
                                    + $"horizontalScrollPos: {this.HorizontalScroll.Value}";
            }
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #region Windows Form Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.label1 = new System.Windows.Forms.Label();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.label1);
                this.panel1.Location = new System.Drawing.Point(134, 165);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(458, 459);
                this.panel1.TabIndex = 0;
                this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(36, 23);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(64, 25);
                this.label1.TabIndex = 1;
                this.label1.Text = "label1";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.AutoScroll = true;
                this.ClientSize = new System.Drawing.Size(505, 421);
                this.Controls.Add(this.panel1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Label label1;
        }
    }
