        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Threading;
        namespace WaitingBox
        {
                public class ShowWaitingBox
                {
                        private class WaitingForm:Form
                        {
                                public WaitingForm()
                                {
                                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                                        this.label1 = new System.Windows.Forms.Label();
                                        this.progressBar1 = new System.Windows.Forms.ProgressBar();
                                        this.tableLayoutPanel1.SuspendLayout();
                                        this.SuspendLayout();
                                        // 
                                        // tableLayoutPanel1
                                        // 
                                        this.tableLayoutPanel1.ColumnCount = 1;
                                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                                        this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 0);
                                        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
                                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                                        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                                        this.tableLayoutPanel1.RowCount = 3;
                                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
                                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                                        this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 155);
                                        this.tableLayoutPanel1.TabIndex = 0;
                                        // 
                                        // label1
                                        // 
                                        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                                        this.label1.AutoSize = true;
                                        this.label1.Location = new System.Drawing.Point(209, 92);
                                        this.label1.Name = "label1";
                                        this.label1.Size = new System.Drawing.Size(73, 13);
                                        this.label1.TabIndex = 3;
                                        this.label1.Text = "Please Wait...";
                                        // 
                                        // progressBar1
                                        // 
                                        this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
                                        this.progressBar1.Location = new System.Drawing.Point(22, 37);
                                        this.progressBar1.Name = "progressBar1";
                                        this.progressBar1.Size = new System.Drawing.Size(447, 23);
                                        this.progressBar1.TabIndex = 2;
                                        // 
                                        // WaitingForm
                                        // 
                                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                                        this.ClientSize = new System.Drawing.Size(492, 155);
                                        this.Controls.Add(this.tableLayoutPanel1);
                                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                                        this.Name = "WaitingForm";
                                        this.Text = "Working in the background";
                                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingForm_FormClosing);
                                        this.Load += new System.EventHandler(this.WaitingForm_Load);
                                        this.tableLayoutPanel1.ResumeLayout(false);
                                        this.tableLayoutPanel1.PerformLayout();
                                        this.ResumeLayout(false);
                                }
                                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                                private System.Windows.Forms.ProgressBar progressBar1;
                                private System.Windows.Forms.Label label1;
                                private void WaitingForm_Load(object sender, EventArgs e)
                                {
                                        progressBar1.Style = ProgressBarStyle.Marquee;
                                        this.BringToFront();
                                }
                                private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
                                {
                                }
                                internal void SetLabel(string p)
                                {
                                        label1.Text = p;
                                }
                        }
                        private WaitingForm wf = new WaitingForm();
                        private string title, text;
                        private Thread waiting;
                        public bool IsAlive
                        {
                                get
                                {
                                        return waiting.IsAlive;
                                }
                                set { }
                        }
                        public ShowWaitingBox(string Title, string Text)
                        {
                                this.title = string.IsNullOrEmpty(Title) ? "Working in the Background..": Title;
                                this.text = string.IsNullOrEmpty(Text) ? "Please wait..." : Text;
                                waiting = new Thread(new ThreadStart(Show));
                        }
                        public ShowWaitingBox()
                        {
                                waiting = new Thread(new ThreadStart(Show));
                        }
                        private void Show()
                        {
                                wf.Show();
                                wf.Text = this.title;
                                wf.SetLabel(this.text);
                                while (true) {
                                
                                        wf.Refresh();
                                        System.Threading.Thread.Sleep(50);
                                }
                        }
                        public void Start()
                        {
                                waiting.Start();
                        }
                        public void Stop()
                        {
                                waiting.Abort();
                        }
                }
        }
