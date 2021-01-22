    namespace RegistryTest1
    {
        partial class Form1
        {
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
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.checkBox1 = new System.Windows.Forms.CheckBox();
                this.button3 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(13, 13);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(641, 20);
                this.textBox1.TabIndex = 0;
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(13, 53);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 1;
                this.button1.Text = "Write key";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(94, 53);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(75, 23);
                this.button2.TabIndex = 2;
                this.button2.Text = "Read key";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // checkBox1
                // 
                this.checkBox1.AutoSize = true;
                this.checkBox1.Location = new System.Drawing.Point(185, 57);
                this.checkBox1.Name = "checkBox1";
                this.checkBox1.Size = new System.Drawing.Size(112, 17);
                this.checkBox1.TabIndex = 3;
                this.checkBox1.Text = "writable parameter";
                this.checkBox1.UseVisualStyleBackColor = true;
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(13, 104);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(75, 23);
                this.button3.TabIndex = 4;
                this.button3.Text = "reset";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(676, 264);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.checkBox1);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.textBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.CheckBox checkBox1;
            private System.Windows.Forms.Button button3;
        }
    }
