            using System;
            using System.Collections.Generic;
            using System.Data;
            using System.Windows.Forms;
            using Infragistics.Win;
            using Infragistics.Win.UltraDataGridView;
            
            namespace IGDataBinding
            {
                public partial class Form1 : Form
                {
                    DataTable dt;
                    List<EqItem> data;
            
                    public Form1()
                    {
                        InitializeComponent();
                    }
            
                    private void Form1_Load(object sender, EventArgs e)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("SN", typeof(int));
                        dt.Columns.Add("Description", typeof(string));
                        dt.Columns.Add("Quantity", typeof(int));
                        dt.Columns.Add("Stock", typeof(int));
            
                        data = new List<EqItem> {
                            new EqItem(1, "Description 1", 10, 100),
                            new EqItem(2, "Description 2", 5, 50),
                            new EqItem(3, "Description 3", 6, 60)
                        };
            
                        dt.AcceptChanges();
                        dataGridView1.AutoGenerateColumns = false;
                        GenerateColumns();
                        dataGridView1.DataSource = dt;
                    }
            
                    [Serializable]
                    public struct EqItem
                    {
                        public int Serial;
                        public string Description;
                        public int Qty;
                        public int Stock;
            
                        public EqItem(int serial, string description, int qty, int stock)
                        {
                            Serial = serial;
                            Description = description;
                            Qty = qty;
                            Stock = stock;
                        }
                    }
            
                    private void GenerateColumns()
                    {
                        UltraTextEditorColumn textEditorColumn = new UltraTextEditorColumn();
                        textEditorColumn.DataPropertyName = "SN";
                        textEditorColumn.Name = "SN";
                        dataGridView1.Columns.Add(textEditorColumn);
            
                        var item = data[0];
                        DataRow drow = dt.NewRow();
                        drow["SN"] = item.Serial;
                        drow["Description"] = item.Description;
                        drow["Quantity"] = item.Qty;
                        drow["Stock"] = item.Stock;
                        dt.Rows.Add();
            
                        UltraComboEditorColumn comboEditorColumn = new UltraComboEditorColumn();
                        comboEditorColumn.DataPropertyName = "UltraComboEditorColumn";
                        comboEditorColumn.Name = "Description";
                        comboEditorColumn.DropDownStyle = DropDownStyle.DropDownList;
            
                        foreach (var qitem in data)
                        {
                            DataRow row = dt.NewRow();
                            row["SN"] = qitem.Serial;
                            row["Description"] = qitem.Description;
                            row["Quantity"] = qitem.Qty;
                            row["Stock"] = qitem.Stock;
                            comboEditorColumn.ValueList.ValueListItems.Add(qitem.Serial - 1, qitem.Description);
                        }
            
                        dataGridView1.Columns.Add(comboEditorColumn);
                        comboEditorColumn.AfterCloseUp += ComboEditorColumn_AfterCloseUp;
            
                        textEditorColumn = new UltraTextEditorColumn
                        {
                            DataPropertyName = "Quantity",
                            Name = "Quantity"
                        };
            
                        dataGridView1.Columns.Add(textEditorColumn);
            
                        textEditorColumn = new UltraTextEditorColumn();
                        textEditorColumn.DataPropertyName = "Stock";
                        textEditorColumn.Name = "Stock";
                        dataGridView1.Columns.Add(textEditorColumn);
                    }
            
                    private void ComboEditorColumn_AfterCloseUp(object sender, EventArgs e)
                    {
                        DataGridViewRow row = dataGridView1.CurrentRow;
            
                        if (row.Cells["Description"] is UltraDataGridViewCell cell)
                        {
                            if (cell.Column is UltraComboEditorColumn vc)
                            {
                                if (vc.Editor is EditorWithCombo editor)
                                {
                                    var text = editor.CurrentEditText;
                                    var current = data.Find(i => i.Description == text);
                                    row.Cells["SN"].Value = current.Serial;
                                    row.Cells["Quantity"].Value = current.Qty;
                                    row.Cells["Stock"].Value = current.Stock;
                                }
                            }
                        }
                    }
                }
            }
    
    namespace IGDataBinding
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
                    this.dataGridView1 = new System.Windows.Forms.DataGridView();
                    ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                    this.SuspendLayout();
                    // 
                    // dataGridView1
                    // 
                    this.dataGridView1.AllowUserToOrderColumns = true;
                    this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                    this.dataGridView1.Name = "dataGridView1";
                    this.dataGridView1.Size = new System.Drawing.Size(487, 405);
                    this.dataGridView1.TabIndex = 0;
                    // 
                    // Form1
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(487, 405);
                    this.Controls.Add(this.dataGridView1);
                    this.Name = "Form1";
                    this.Text = "Form1";
                    this.Load += new System.EventHandler(this.Form1_Load);
                    ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                    this.ResumeLayout(false);
        
                }
        
                #endregion
        
                private System.Windows.Forms.DataGridView dataGridView1;
            }
    }
