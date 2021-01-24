    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
    
    namespace WPFDataTriggers
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private bool isFB = true;
            public bool IsFB
            {
                get { return isFB; }
                set
                {
                    isFB = value;
                    this.NotifyPropertyChanged("IsFB");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string nomPropriete)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
    
            private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
            {
                if (object.Equals(variable, valeur)) return false;
    
                variable = valeur;
                NotifyPropertyChanged(nomPropriete);
                return true;
            }
            public MainWindow()
            {
                InitializeComponent();
                IsFB = true;
                this.DataContext = this;
            }
        }
    }
