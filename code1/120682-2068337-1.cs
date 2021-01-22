    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    namespace WpfTEST {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window, INotifyPropertyChanged {
            public Window1() {
                InitializeComponent();
                this.Loaded += new RoutedEventHandler(Window1_Loaded);
                this.PropertyChanged += new PropertyChangedEventHandler(Window1_PropertyChanged);
            }
            public bool Flag {
                get { return m_flag; }
                set {
                    m_flag = value;
                    OnPropertyChanged("Flag");
                }
            }
            private bool m_flag = false;
            void Window1_Loaded( object sender, RoutedEventArgs e ) {
                this.m_cbox.DataContext = this;
                Flag = false;
            }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged( string name ) {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            void Window1_PropertyChanged( object sender, PropertyChangedEventArgs e ) {
            }
            #endregion
            private void Button_Click( object sender, RoutedEventArgs e ) {
                Flag = !Flag;
            }
        }
    }
