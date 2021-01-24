    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace UserObjectsLeak
    {
        public partial class FrmUserObjectsLeak : Form
        {
            // This is used to keep references of the labels being added dynamically.
            static readonly List<Label> Labels = new List<Label>();
            public FrmUserObjectsLeak()
            {
                InitializeComponent();
            }
            private void btnStart_Click(object sender, EventArgs e)
            {
                for (var i = 0; i < 11000; i++)
                {
                    var label = new Label()
                    {
                        Text = i.ToString(),
                        Width = 50
                    };
                    Labels.Add(label);
                    try
                    {
                        panel1.Controls.Add(label);
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        lblException.Text = ex.ToString();
                        return;
                    }
                    lblControlsCount.Text = (i).ToString();
                
                    // Quick and dirty just to show the progress...
                    Application.DoEvents();
                
                    if (i % 500 == 0)
                    {
                        // Remove all labels from the panel,
                        // keep only the reference in the list.
                        panel1.Controls.Clear();
                    }
                }
            }
            private void btnClear_Click(object sender, EventArgs e)
            {
                panel1.Controls.Clear();
                Labels.Clear();
                lblControlsCount.Text = "";
                lblException.Text = "";
            }
            #region Designer code
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
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.btnStart = new System.Windows.Forms.Button();
                this.lblControlsCount = new System.Windows.Forms.Label();
                this.btnClear = new System.Windows.Forms.Button();
                this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
                this.lblException = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(15, 17);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(191, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "Click the button to start adding controls";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(12, 95);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(77, 13);
                this.label2.TabIndex = 1;
                this.label2.Text = "controls count:";
                // 
                // btnStart
                // 
                this.btnStart.Location = new System.Drawing.Point(12, 49);
                this.btnStart.Name = "btnStart";
                this.btnStart.Size = new System.Drawing.Size(75, 23);
                this.btnStart.TabIndex = 2;
                this.btnStart.Text = "Start";
                this.btnStart.UseVisualStyleBackColor = true;
                this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
                // 
                // lblControlsCount
                // 
                this.lblControlsCount.AutoSize = true;
                this.lblControlsCount.Location = new System.Drawing.Point(95, 95);
                this.lblControlsCount.Name = "lblControlsCount";
                this.lblControlsCount.Size = new System.Drawing.Size(0, 13);
                this.lblControlsCount.TabIndex = 3;
                // 
                // btnClear
                // 
                this.btnClear.Location = new System.Drawing.Point(98, 49);
                this.btnClear.Name = "btnClear";
                this.btnClear.Size = new System.Drawing.Size(75, 23);
                this.btnClear.TabIndex = 5;
                this.btnClear.Text = "Clear";
                this.btnClear.UseVisualStyleBackColor = true;
                this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
                // 
                // panel1
                // 
                this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                this.panel1.Location = new System.Drawing.Point(226, 17);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(200, 148);
                this.panel1.TabIndex = 6;
                // 
                // lblException
                // 
                this.lblException.AutoSize = true;
                this.lblException.Location = new System.Drawing.Point(15, 179);
                this.lblException.Name = "lblException";
                this.lblException.Size = new System.Drawing.Size(0, 13);
                this.lblException.TabIndex = 7;
                // 
                // frmUserObjectsLeak
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(452, 308);
                this.Controls.Add(this.lblException);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.btnClear);
                this.Controls.Add(this.lblControlsCount);
                this.Controls.Add(this.btnStart);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Name = "FrmUserObjectsLeak";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "User Objects Leak Demo";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Button btnStart;
            private System.Windows.Forms.Label lblControlsCount;
            private System.Windows.Forms.Button btnClear;
            private System.Windows.Forms.FlowLayoutPanel panel1;
            private System.Windows.Forms.Label lblException;
            #endregion Designer code
        }
    }
