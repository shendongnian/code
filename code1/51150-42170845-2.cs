    using System;
    using System.Data;
    using System.Windows.Forms;
    
    public partial class frmTestAutocomplete : Form
    {
    
        private DataTable maoCompleteList; //the data table from your data source
        private string msDisplayCol = "name"; //displayed text
        private string msIDcol = "id"; //ID or primary key
    
        public frmTestAutocomplete(DataTable aoCompleteList, string sDisplayCol, string sIDcol)
        {
            InitializeComponent();
            maoCompleteList = aoCompleteList
            maoCompleteList.CaseSensitive = false; //turn off case sensitivity for searching
            msDisplayCol = sDisplayCol;
            msIDcol = sIDcol;
        }
    
        private void frmTestAutocomplete_Load(object sender, EventArgs e)
        {
    
                testCombo.DisplayMember = msDisplayCol;
                testCombo.ValueMember = msIDcol; 
                testCombo.DataSource = maoCompleteList;
                testCombo.SelectedIndexChanged += testCombo_SelectedIndexChanged;
                testCombo.KeyUp += testCombo_KeyUp; 
            
        }
    
    
        private void testCombo_KeyUp(object sender, KeyEventArgs e)
        {
            //use keyUp event, as text changed traps too many other evengts.
    
            ComboBox oBox = (ComboBox)sender;
            string sBoxText = oBox.Text;
    
            DataRow[] oFilteredRows = maoCompleteList.Select(MC_DISPLAY_COL + " Like '%" + sBoxText + "%'");
    
            DataTable oFilteredDT = oFilteredRows.Length > 0
                                    ? oFilteredRows.CopyToDataTable()
                                    : maoCompleteList;
    
            //NOW THAT WE HAVE OUR FILTERED LIST, WE NEED TO RE-BIND IT WIHOUT CHANGING THE TEXT IN THE ComboBox.
    
            //1).UNREGISTER THE SELECTED EVENT BEFORE RE-BINDING, b/c IT TRIGGERS ON BIND.
            testCombo.SelectedIndexChanged -= testCombo_SelectedIndexChanged; //don't select on typing.
            oBox.DataSource = oFilteredDT; //2).rebind to filtered list.
            testCombo.SelectedIndexChanged += testCombo_SelectedIndexChanged;
            //3).show the user the new filtered list.
            oBox.DroppedDown = true; //do this before repainting the text, as it changes the dropdown text.
    
            //4).binding data source erases text, so now we need to put the user's text back,
            oBox.Text = sBoxText;
            oBox.SelectionStart = sBoxText.Length; //5). need to put the user's cursor back where it was.
    
    
        }
    
        private void testCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            ComboBox oBox = (ComboBox)sender;
    
            if (oBox.SelectedValue != null)
            {
                MessageBox.Show(string.Format(@"Item #{0} was selected.", oBox.SelectedValue));
            }
        }
    }
    
    //=====================================================================================================
    //      code from frmTestAutocomplete.Designer.cs
    //=====================================================================================================
    partial class frmTestAutocomplete
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
            this.testCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // testCombo
            // 
            this.testCombo.FormattingEnabled = true;
            this.testCombo.Location = new System.Drawing.Point(27, 51);
            this.testCombo.Name = "testCombo";
            this.testCombo.Size = new System.Drawing.Size(224, 21);
            this.testCombo.TabIndex = 0;
            // 
            // frmTestAutocomplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.testCombo);
            this.Name = "frmTestAutocomplete";
            this.Text = "frmTestAutocomplete";
            this.Load += new System.EventHandler(this.frmTestAutocomplete_Load);
            this.ResumeLayout(false);
    
        }
    
        #endregion
    
        private System.Windows.Forms.ComboBox testCombo;
    }
