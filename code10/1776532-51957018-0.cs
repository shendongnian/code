    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml.Linq;
    using System.Xml.XmlConfiguration;
    namespace RAS_ERP
    {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var UName = TxtUsername.Text;
            var PWord = TxtPassword.Text;
            XDocument config = XDocument.Load("../Resources/config.xml");
            var query = from o in config.Root.Elements("user")
                        where (string)o.Element("username") == UName
                        select (string)o.Element("username").Value;
            var query2 = from o in config.Root.Elements("user")
                         where (string)o.Element("username") == UName
                         select o.Element("password").Value;
            var password = query2.ToString();
                if ( PWord == password )
                {
                    NavigationService service = NavigationService.GetNavigationService(this);
                    service.Navigate(new Uri("MainMenu.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    LblError.Content = "Username or Password Incorrect !";
                }
            }
        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
    }
