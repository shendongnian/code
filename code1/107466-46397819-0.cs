    // MainForm.cs
    public partial class MainForm : Form
       public MainForm() 
       {
         /* code for parsing configuration parameters which producs in <myObj> myConfig */
         InitializeComponent();
         myUserControl1.config = myConfig; // set the config property to myConfig object
       }
    //myUserControl.Designer.cs
    partial class myUserControl
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
        // define the public property to hold the config and give it a default value
        private myObj _config = new myObj(param1, param2, ...);      
        public myObj config
        {
            get
            {
                return _config ;
            }
            set
            {
                _config = value;
            }
        }
        #region Component Designer generated code
        ...
    }
