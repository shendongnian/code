    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void cb_ADC_RPA0_CheckedChanged(object sender, EventArgs e)
            {
                /* Disable pin on other peripherals */
                cb_UART_RPA0.Enabled = !((CheckBox)sender).Checked;
                cb_PWM_RPA0.Enabled = !((CheckBox)sender).Checked;
                SetTootTip((CheckBox)sender, lbl_PWM_RPA0, lbl_UART_RPA0, "ADC");
                
            }
            
            private void cb_PWM_RPA0_CheckedChanged(object sender, EventArgs e)
            {
                /* Disable pin on other peripherals */
                cb_UART_RPA0.Enabled = !((CheckBox)sender).Checked;
                cb_ADC_RPA0.Enabled = !((CheckBox)sender).Checked;
                
                SetTootTip((CheckBox)sender, lbl_ADC_RPA0, lbl_UART_RPA0, "PWM");
            }
            private void cb_UART_RPA0_CheckedChanged(object sender, EventArgs e)
            {
                /* Disable pin on other peripherals */
                cb_ADC_RPA0.Enabled = !((CheckBox)sender).Checked;
                cb_PWM_RPA0.Enabled = !((CheckBox)sender).Checked;
                SetTootTip((CheckBox)sender, lbl_ADC_RPA0, lbl_PWM_RPA0, "UART");
                
            }
            void SetTootTip(CheckBox sender, Label lbl1, Label lbl2, string text)
            {
                /* Update tooltip on the other labels */
                if (sender.Checked)
                {
                    toolTip1.SetToolTip(lbl1, "Used by " + text);
                    toolTip1.SetToolTip(lbl2, "Used by " + text);
                }
                else
                {
                    toolTip1.SetToolTip(lbl1, "");
                    toolTip1.SetToolTip(lbl2, "");
                }
            }
        }
    }
    namespace WindowsFormsApplication1
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
                this.components = new System.ComponentModel.Container();
                this.tabControl1 = new System.Windows.Forms.TabControl();
                this.tpPWM = new System.Windows.Forms.TabPage();
                this.tpUART = new System.Windows.Forms.TabPage();
                this.tpADC = new System.Windows.Forms.TabPage();
                this.cb_PWM_RPA0 = new System.Windows.Forms.CheckBox();
                this.cb_ADC_RPA0 = new System.Windows.Forms.CheckBox();
                this.lbl_PWM_RPA0 = new System.Windows.Forms.Label();
                this.lbl_ADC_RPA0 = new System.Windows.Forms.Label();
                this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
                this.lbl_UART_RPA0 = new System.Windows.Forms.Label();
                this.cb_UART_RPA0 = new System.Windows.Forms.CheckBox();
                this.tabControl1.SuspendLayout();
                this.tpPWM.SuspendLayout();
                this.tpUART.SuspendLayout();
                this.tpADC.SuspendLayout();
                this.SuspendLayout();
                // 
                // tabControl1
                // 
                this.tabControl1.Controls.Add(this.tpPWM);
                this.tabControl1.Controls.Add(this.tpUART);
                this.tabControl1.Controls.Add(this.tpADC);
                this.tabControl1.Location = new System.Drawing.Point(12, 12);
                this.tabControl1.Name = "tabControl1";
                this.tabControl1.SelectedIndex = 0;
                this.tabControl1.Size = new System.Drawing.Size(629, 296);
                this.tabControl1.TabIndex = 0;
                // 
                // tpPWM
                // 
                this.tpPWM.Controls.Add(this.lbl_PWM_RPA0);
                this.tpPWM.Controls.Add(this.cb_PWM_RPA0);
                this.tpPWM.Location = new System.Drawing.Point(4, 22);
                this.tpPWM.Name = "tpPWM";
                this.tpPWM.Padding = new System.Windows.Forms.Padding(3);
                this.tpPWM.Size = new System.Drawing.Size(621, 270);
                this.tpPWM.TabIndex = 0;
                this.tpPWM.Text = "PWM";
                this.tpPWM.UseVisualStyleBackColor = true;
                // 
                // tpUART
                // 
                this.tpUART.Controls.Add(this.cb_UART_RPA0);
                this.tpUART.Controls.Add(this.lbl_UART_RPA0);
                this.tpUART.Location = new System.Drawing.Point(4, 22);
                this.tpUART.Name = "tpUART";
                this.tpUART.Padding = new System.Windows.Forms.Padding(3);
                this.tpUART.Size = new System.Drawing.Size(621, 270);
                this.tpUART.TabIndex = 1;
                this.tpUART.Text = "UART";
                this.tpUART.UseVisualStyleBackColor = true;
                // 
                // tpADC
                // 
                this.tpADC.Controls.Add(this.lbl_ADC_RPA0);
                this.tpADC.Controls.Add(this.cb_ADC_RPA0);
                this.tpADC.Location = new System.Drawing.Point(4, 22);
                this.tpADC.Name = "tpADC";
                this.tpADC.Padding = new System.Windows.Forms.Padding(3);
                this.tpADC.Size = new System.Drawing.Size(621, 270);
                this.tpADC.TabIndex = 2;
                this.tpADC.Text = "ADC";
                this.tpADC.UseVisualStyleBackColor = true;
                // 
                // cb_PWM_RPA0
                // 
                this.cb_PWM_RPA0.AutoSize = true;
                this.cb_PWM_RPA0.Location = new System.Drawing.Point(17, 65);
                this.cb_PWM_RPA0.Name = "cb_PWM_RPA0";
                this.cb_PWM_RPA0.Size = new System.Drawing.Size(15, 14);
                this.cb_PWM_RPA0.TabIndex = 0;
                this.cb_PWM_RPA0.UseVisualStyleBackColor = true;
                this.cb_PWM_RPA0.CheckedChanged += new System.EventHandler(this.cb_PWM_RPA0_CheckedChanged);
                // 
                // cb_ADC_RPA0
                // 
                this.cb_ADC_RPA0.AutoSize = true;
                this.cb_ADC_RPA0.Location = new System.Drawing.Point(17, 65);
                this.cb_ADC_RPA0.Name = "cb_ADC_RPA0";
                this.cb_ADC_RPA0.Size = new System.Drawing.Size(15, 14);
                this.cb_ADC_RPA0.TabIndex = 1;
                this.cb_ADC_RPA0.UseVisualStyleBackColor = true;
                this.cb_ADC_RPA0.CheckedChanged += new System.EventHandler(this.cb_ADC_RPA0_CheckedChanged);
                // 
                // lbl_PWM_RPA0
                // 
                this.lbl_PWM_RPA0.AutoSize = true;
                this.lbl_PWM_RPA0.Location = new System.Drawing.Point(38, 65);
                this.lbl_PWM_RPA0.Name = "lbl_PWM_RPA0";
                this.lbl_PWM_RPA0.Size = new System.Drawing.Size(35, 13);
                this.lbl_PWM_RPA0.TabIndex = 1;
                this.lbl_PWM_RPA0.Text = "RPA0";
                // 
                // lbl_ADC_RPA0
                // 
                this.lbl_ADC_RPA0.AutoSize = true;
                this.lbl_ADC_RPA0.Location = new System.Drawing.Point(38, 66);
                this.lbl_ADC_RPA0.Name = "lbl_ADC_RPA0";
                this.lbl_ADC_RPA0.Size = new System.Drawing.Size(35, 13);
                this.lbl_ADC_RPA0.TabIndex = 2;
                this.lbl_ADC_RPA0.Text = "RPA0";
                // 
                // lbl_UART_RPA0
                // 
                this.lbl_UART_RPA0.AutoSize = true;
                this.lbl_UART_RPA0.Location = new System.Drawing.Point(37, 65);
                this.lbl_UART_RPA0.Name = "lbl_UART_RPA0";
                this.lbl_UART_RPA0.Size = new System.Drawing.Size(35, 13);
                this.lbl_UART_RPA0.TabIndex = 4;
                this.lbl_UART_RPA0.Text = "RPA0";
                // 
                // cb_UART_RPA0
                // 
                this.cb_UART_RPA0.AutoSize = true;
                this.cb_UART_RPA0.Location = new System.Drawing.Point(16, 65);
                this.cb_UART_RPA0.Name = "cb_UART_RPA0";
                this.cb_UART_RPA0.Size = new System.Drawing.Size(15, 14);
                this.cb_UART_RPA0.TabIndex = 5;
                this.cb_UART_RPA0.UseVisualStyleBackColor = true;
                this.cb_UART_RPA0.CheckedChanged += new System.EventHandler(this.cb_UART_RPA0_CheckedChanged);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(758, 429);
                this.Controls.Add(this.tabControl1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.tabControl1.ResumeLayout(false);
                this.tpPWM.ResumeLayout(false);
                this.tpPWM.PerformLayout();
                this.tpUART.ResumeLayout(false);
                this.tpUART.PerformLayout();
                this.tpADC.ResumeLayout(false);
                this.tpADC.PerformLayout();
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.TabControl tabControl1;
            private System.Windows.Forms.TabPage tpPWM;
            private System.Windows.Forms.Label lbl_PWM_RPA0;
            private System.Windows.Forms.CheckBox cb_PWM_RPA0;
            private System.Windows.Forms.TabPage tpUART;
            private System.Windows.Forms.TabPage tpADC;
            private System.Windows.Forms.Label lbl_ADC_RPA0;
            private System.Windows.Forms.CheckBox cb_ADC_RPA0;
            private System.Windows.Forms.ToolTip toolTip1;
            private System.Windows.Forms.CheckBox cb_UART_RPA0;
            private System.Windows.Forms.Label lbl_UART_RPA0;
        }
    }
