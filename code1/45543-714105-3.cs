    #region
    
    using System.ComponentModel;
    using System.Windows.Forms;
    
    #endregion
    
    namespace DataGridViewTest
    {
        public class GridTest : Form
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private IContainer components;
    
            private DataGridView dataGridView1;
            private DataGridViewTextBoxColumn Month;
    
            public GridTest()
            {
                InitializeComponent();
            }
    
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
    
            private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
            {
                DataGridView gridView = sender as DataGridView;
    
                if (null != gridView)
                {
                    gridView.Rows[e.RowIndex].HeaderCell.Value = "2009";
                }
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
                ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.ColumnHeadersHeightSizeMode =
                    System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                        {
                                                            this.Month
                                                        });
                this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.RowHeadersWidth = 100;
                this.dataGridView1.Size = new System.Drawing.Size(745, 532);
                this.dataGridView1.TabIndex = 0;
                this.dataGridView1.RowValidated +=
                    new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
                // 
                // Month
                // 
                this.Month.HeaderText = "Month";
                this.Month.Name = "Month";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(745, 532);
                this.Controls.Add(this.dataGridView1);
                this.Name = "Form1";
                this.Text = "Form1";
                ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
                this.ResumeLayout(false);
            }
    
            #endregion
        }
    }
