        using System.Configuration;
    
    namespace WindowsFormsApplication1
    {
      class MySettings : ApplicationSettingsBase
      {
        [UserScopedSetting]
        public string SavedString
        {
          get { return ( string )this["SavedString"]; }
          set { this["SavedString"] = value; }
        }
      } 
    
      public partial class Form1 : Form
      {
        MySettings m_Settings;
    
        public Form1()
        {
          InitializeComponent();
        }
    
        private void Form1_Load( object sender, EventArgs e )
        {
          m_Settings = new MySettings();
    
          Binding b = new Binding( "Text", m_Settings, "SavedString", true, DataSourceUpdateMode.OnPropertyChanged );
          this.DataBindings.Add( b );
        }
    
        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
          m_Settings.Save();
        }
    
        private void button1_Click( object sender, EventArgs e )
        {
          this.Text = "My Text";
        }
      }
    }
    
    
    
