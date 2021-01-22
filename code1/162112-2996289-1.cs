    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfWindow
    {
      public partial class Window1 : Window
      {
        private const int NumberOfRecords = 20;
        private readonly ObservableCollection<Person> _myList;
    
        public Window1()
        {
          InitializeComponent();
    
          var countries = new[] { "", "US", "China", "India", "Japan", "Ukraine" };
    
          var countriesCount = countries.Length;
          _myList = new ObservableCollection<Person>();
          var rnd = new Random();
    
          for (int i = 0; i < NumberOfRecords; i++)
          {
            int countryIndex = rnd.Next(countriesCount);
            _myList.Add(new Person() { Name = string.Format("Name {0}", i), Country = countries[countryIndex] });
          }
    
          ICollectionView view = CollectionViewSource.GetDefaultView(_myList);
          view.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
          view.SortDescriptions.Add(new SortDescription("Country", ListSortDirection.Ascending));
          view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    
          lv.ItemsSource = view;
        }
      }
    
      public class Person
      {
        public string Name { get; set; }
        public string Country { get; set; }
      }
    
      public class CountryStyleSelector : StyleSelector
      {
        public Style RegularGroupStyle { get; set; }
    
        public Style RootGroup { get; set; }
    
        public override Style SelectStyle(object item, DependencyObject container)
        {
          var cvg = item as CollectionViewGroup;
          if (cvg == null)
          {
            return base.SelectStyle(item, container);
          }
          return string.IsNullOrEmpty(cvg.Name as string) ? RootGroup : RegularGroupStyle;
        }
      }
    }
