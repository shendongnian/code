    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.Sql;
    
    namespace Palmaris_Installation
    {
        public class efexBox
        {
            public static string ShowDialog()
            {
                PopUpDatabase form = new PopUpDatabase();
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.Cancel)
                    return null;
                else
                {
                    if (form.ValueAuthentication == "SQL Server Authentication")
                    return form.Valueservername + "?" + form.ValueAuthentication + "?" + form.ValueUsername + "?" + form.ValuePassword;
                    else
                        return form.Valueservername + "?" + form.ValueAuthentication + "?" + "" + "?" + "";
                }
            }
    
            public partial class PopUpDatabase : Form
            {
                public PopUpDatabase()
                {
                    InitializeComponent();
                    
                    SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                    DataTable table = instance.GetDataSources();
    
                    foreach (DataRow row in table.Rows)
                    {
                        cmbServerName.Items.Add(row[0] + "\\" + row[1]);
                    }
                    cmbAuthentication.Items.Add("Windows Authentication");
                    cmbAuthentication.Items.Add("SQL Server Authentication");
                    return;
                }
    
                private void InitializeComponent()
                {
                    this.groupBox1 = new System.Windows.Forms.GroupBox();
                    this.label1 = new System.Windows.Forms.Label();
                    this.label2 = new System.Windows.Forms.Label();
                    this.label3 = new System.Windows.Forms.Label();
                    this.label4 = new System.Windows.Forms.Label();
                    this.cmbServerName = new System.Windows.Forms.ComboBox();
                    this.cmbAuthentication = new System.Windows.Forms.ComboBox();
                    this.txtUserName = new System.Windows.Forms.TextBox();
                    this.txtPassword = new System.Windows.Forms.TextBox();
                    this.btnCancel = new System.Windows.Forms.Button();
                    this.btnConnect = new System.Windows.Forms.Button();
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    this.MaximizeBox = false;
                    this.groupBox1.SuspendLayout();
                    this.SuspendLayout();
    
                    // 
                    // groupBox1
                    // 
                    this.groupBox1.Controls.Add(this.btnConnect);
                    this.groupBox1.Controls.Add(this.btnCancel);
                    this.groupBox1.Controls.Add(this.txtPassword);
                    this.groupBox1.Controls.Add(this.txtUserName);
                    this.groupBox1.Controls.Add(this.cmbAuthentication);
                    this.groupBox1.Controls.Add(this.cmbServerName);
                    this.groupBox1.Controls.Add(this.label4);
                    this.groupBox1.Controls.Add(this.label3);
                    this.groupBox1.Controls.Add(this.label2);
                    this.groupBox1.Controls.Add(this.label1);
                    this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.groupBox1.Location = new System.Drawing.Point(0, 0);
                    this.groupBox1.Name = "groupBox1";
                    this.groupBox1.Size = new System.Drawing.Size(348, 198);
                    this.groupBox1.TabIndex = 0;
                    this.groupBox1.TabStop = false;
                    this.groupBox1.Text = "Database Configration";
                    this.groupBox1.BackColor = Color.Gray;
                    // 
                    // label1
                    // 
                    this.label1.AutoSize = true;
                    this.label1.Location = new System.Drawing.Point(50, 46);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(69, 13);
                    this.label1.TabIndex = 0;
                    this.label1.Text = "Server Name";
                    // 
                    // label2
                    // 
                    this.label2.AutoSize = true;
                    this.label2.Location = new System.Drawing.Point(50, 73);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(75, 13);
                    this.label2.TabIndex = 0;
                    this.label2.Text = "Authentication";
                    // 
                    // label3
                    // 
                    this.label3.AutoSize = true;
                    this.label3.Location = new System.Drawing.Point(50, 101);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(60, 13);
                    this.label3.TabIndex = 0;
                    this.label3.Text = "User Name";
                    // 
                    // label4
                    // 
                    this.label4.AutoSize = true;
                    this.label4.Location = new System.Drawing.Point(50, 127);
                    this.label4.Name = "label4";
                    this.label4.Size = new System.Drawing.Size(53, 13);
                    this.label4.TabIndex = 0;
                    this.label4.Text = "Password";
                    // 
                    // cmbServerName
                    // 
                    this.cmbServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    this.cmbServerName.FormattingEnabled = true;
                    this.cmbServerName.Location = new System.Drawing.Point(140, 43);
                    this.cmbServerName.Name = "cmbServerName";
                    this.cmbServerName.Size = new System.Drawing.Size(185, 21);
                    this.cmbServerName.TabIndex = 1;
                    // 
                    // cmbAuthentication
                    // 
                    this.cmbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    this.cmbAuthentication.FormattingEnabled = true;
                    this.cmbAuthentication.Location = new System.Drawing.Point(140, 70);
                    this.cmbAuthentication.Name = "cmbAuthentication";
                    this.cmbAuthentication.Size = new System.Drawing.Size(185, 21);
                    this.cmbAuthentication.TabIndex = 1;
                    this.cmbAuthentication.SelectedIndexChanged += new System.EventHandler(this.cmbAuthentication_SelectedIndexChanged);
                    // 
                    // txtUserName
                    // 
                    this.txtUserName.Location = new System.Drawing.Point(140, 98);
                    this.txtUserName.Name = "txtUserName";
                    this.txtUserName.Size = new System.Drawing.Size(185, 20);
                    this.txtUserName.TabIndex = 2;
                    // 
                    // txtPassword
                    // 
                    this.txtPassword.Location = new System.Drawing.Point(140, 124);
                    this.txtPassword.Name = "txtPassword";
                    this.txtPassword.Size = new System.Drawing.Size(185, 20);
                    this.txtPassword.TabIndex = 2;
                    // 
                    // btnCancel
                    // 
                    this.btnCancel.Location = new System.Drawing.Point(250, 163);
                    this.btnCancel.Name = "btnCancel";
                    this.btnCancel.Size = new System.Drawing.Size(75, 23);
                    this.btnCancel.TabIndex = 3;
                    this.btnCancel.Text = "Cancel";
                    this.btnCancel.UseVisualStyleBackColor = true;
                    this.btnCancel.DialogResult = DialogResult.Cancel;
                    // 
                    // btnConnect
                    // 
                    this.btnConnect.Location = new System.Drawing.Point(140, 163);
                    this.btnConnect.Name = "btnConnect";
                    this.btnConnect.Size = new System.Drawing.Size(75, 23);
                    this.btnConnect.TabIndex = 3;
                    this.btnConnect.Text = "Connect";
                    this.btnConnect.UseVisualStyleBackColor = true;
                    this.btnConnect.DialogResult = DialogResult.OK;
                    // 
                    // PopUpDatabase
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(348, 198);
                    this.Controls.Add(this.groupBox1);
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    this.Name = "PopUpDatabase";
                    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    this.Text = "::: Database Configration :::";
                    this.groupBox1.ResumeLayout(false);
                    this.groupBox1.PerformLayout();
                    this.ResumeLayout(false);
    
                }
    
                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.TextBox txtPassword;
                private System.Windows.Forms.TextBox txtUserName;
                private System.Windows.Forms.ComboBox cmbAuthentication;
                private System.Windows.Forms.ComboBox cmbServerName;
                private System.Windows.Forms.Button btnConnect;
                private System.Windows.Forms.Button btnCancel;
    
                public string ValueUsername { get { return txtUserName.Text; } }
                public string ValuePassword { get { return txtPassword.Text; } }
                public string Valueservername { get { return cmbServerName.SelectedItem.ToString(); } }
                public string ValueAuthentication { get { return cmbAuthentication.SelectedItem.ToString(); } }
    
                private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (cmbAuthentication.SelectedIndex == 1)
                    {
                        txtUserName.Enabled = true;
                        txtPassword.Enabled = true;
                    }
                    else
                    {
                        txtUserName.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                }
            }
        }
    }
