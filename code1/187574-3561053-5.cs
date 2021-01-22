    using System;
    using System.Collections.Generic;
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
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.ComponentModel;
    
    namespace WpfApplication1
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
            
            private void rb1_Checked(object sender, RoutedEventArgs e)
            {
                (this.DataContext as ViewModel).UpdateFilter(true);
            }
    
            private void rb2_Checked(object sender, RoutedEventArgs e)
            {
                (this.DataContext as ViewModel).UpdateFilter(false);
            }
        }
    
        public class ViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Animal> animals = new ObservableCollection<Animal>();
            private ListCollectionView animalsCollectionView;
    
            public ListCollectionView AnimalsCollectionView
            {
                get { return this.animalsCollectionView; }
            }
    
            public void UpdateFilter(bool showMammals)
            {
                this.animalsCollectionView.Filter = new Predicate<object>((p) => (p as Animal).IsMammal == showMammals);
                this.animalsCollectionView.Refresh();
            }
    
            public ViewModel()
            { 
                this.animals.Add(new Animal() { Name = "Dog", IsMammal = true });
                this.animals.Add(new Animal() { Name = "Cat", IsMammal = true });
                this.animals.Add(new Animal() { Name = "Bird", IsMammal = false });
    
                this.animalsCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(this.animals);
    
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
    
            #endregion
        }
    
        public class Animal : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get { return this.name; }
                set
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
    
            private bool isMammal;
            public bool IsMammal
            {
                get { return this.isMammal; }
                set
                {
                    this.isMammal = value;
                    this.OnPropertyChanged("IsMammal");
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
    
            #endregion
        }
        
    }
