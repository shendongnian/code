    namespace WindowsFormsApp1
    {
       using System.Windows.Forms;
    
       using IniParser;
    
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
             var parser = new FileIniDataParser();
             var data = parser.ReadFile("Configuration.ini");
    
             var useFullScreenStr = data["UI"]["fullscreen"];
    
             var useFullScreen = bool.Parse(useFullScreenStr);
    
             data["UI"]["fullscreen"] = "true";
             parser.WriteFile("Configuration.ini", data);
          }
       }
    }
