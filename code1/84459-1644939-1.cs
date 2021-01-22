    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ValidationApp
    {
        public  class ValidationTestForm : Form
        {
            private TextBox textBox1;
            private TextBox textBox2;
            private Button btnSave;
            private ErrorProvider errorProvider1;
    
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
                this.components = new System.ComponentModel.Container();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.btnSave = new System.Windows.Forms.Button();
                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(131, 28);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(100, 20);
                this.textBox1.TabIndex = 0;
                // 
                // textBox2
                // 
                this.textBox2.Location = new System.Drawing.Point(131, 65);
                this.textBox2.Name = "textBox2";
                this.textBox2.Size = new System.Drawing.Size(100, 20);
                this.textBox2.TabIndex = 1;
                // 
                // btnSave
                // 
                this.btnSave.Location = new System.Drawing.Point(76, 102);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(95, 30);
                this.btnSave.TabIndex = 2;
                this.btnSave.Text = "Save";
                this.btnSave.UseVisualStyleBackColor = true;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // errorProvider1
                // 
                this.errorProvider1.ContainerControl = this;
                // 
                // ValidationTestForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(266, 144);
                this.Controls.Add(this.btnSave);
                this.Controls.Add(this.textBox2);
                this.Controls.Add(this.textBox1);
                this.Name = "ValidationTestForm";
                this.Text = "ValidationTestForm";
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
        
            public ValidationTestForm()
            {
                InitializeComponent();
    
                // path validation
                this.AutoValidate = AutoValidate.Disable; // validation to happen only when you call ValidateChildren, not when change focus
                this.textBox1.CausesValidation = true;
                this.textBox2.CausesValidation = true;
                textBox1.Validating += new System.ComponentModel.CancelEventHandler(textBox1_Validating);
                textBox2.Validating += new System.ComponentModel.CancelEventHandler(textBox2_Validating);
    
            }
    
            private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (textBox1.Text.Length == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(this.textBox1, "A value is required.");
                }
                else
                {
                    e.Cancel = false;
                    this.errorProvider1.SetError(this.textBox1, "");
                }
            }
    
            private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (textBox2.Text.Length == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(this.textBox2, "A value is required.");
                }
                else
                {
                    e.Cancel = false;
                    this.errorProvider1.SetError(this.textBox2, "");
                }
            }
    
       
    
            private void btnSave_Click(object sender, EventArgs e)
            {
                if (this.ValidateChildren()) //will examine all the children of the current control, causing the Validating event to occur on a control 
                {
                    // Validated! - Do something then
                }
     
            }
        }
    }
    
