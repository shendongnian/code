    using System;
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
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Windows.Forms;
    using System.Timers;
    
    namespace GoogleDDNS
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (username.Text == "")
                {
                    System.Windows.MessageBox.Show("Please enter the username");
                    username.Focus();
                    return;
                }
                if (password.Text == "")
                {
                    System.Windows.MessageBox.Show("Please enter the password");
                    password.Focus();
                    return;
                }
                if (subdomain.Text == "")
                {
                    System.Windows.MessageBox.Show("Please enter the subdomain");
                    subdomain.Focus();
                    return;
                }
    
                var client = new WebClient { Credentials = new NetworkCredential(username.Text, password.Text) };
                var response = client.DownloadString("https://domains.google.com/nic/update?hostname=" + subdomain.Text);
                //MessageBox.Show(response);
                responseddns.Content = response;
    
    
    
                Properties.Settings.Default.usernamesave = username.Text;
                Properties.Settings.Default.passwordsave = password.Text;
                Properties.Settings.Default.subdomainsave = subdomain.Text;
                //Properties.Settings.Default.intervalsave = interval.Text;
                Properties.Settings.Default.Save();
    
    
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                username.Text = Properties.Settings.Default.usernamesave;
                password.Text = Properties.Settings.Default.passwordsave;
                subdomain.Text = Properties.Settings.Default.subdomainsave;
                //interval.Text = Properties.Settings.Default.intervalsave;
    
    
                System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
                MyTimer.Interval = (1 * 60 * 1000); // 45 mins
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();
    
            }
            private void MyTimer_Tick(object sender, EventArgs e)
            {
                var client = new WebClient { Credentials = new NetworkCredential(username.Text, password.Text) };
                var response = client.DownloadString("https://domains.google.com/nic/update?hostname=" + subdomain.Text);
                //MessageBox.Show(response);
                responseddns.Content = response;
                //this.Close();
            }
    
        }
    }
