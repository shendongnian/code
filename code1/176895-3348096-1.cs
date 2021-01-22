    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Microsoft.Windows.Controls;
    
    namespace DataGridDemo
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                PeopleData = new DataTable();
                PeopleData.Columns.Add(new DataColumn("Name", typeof(string)));
                PeopleData.Columns.Add(new DataColumn("Age", typeof(int)));
    
                var row = PeopleData.NewRow();
                row["Name"] = "Sara";
                row["Age"] = 25;
                PeopleData.Rows.Add(row);
    
                row = PeopleData.NewRow();
                row["Name"] = "Bob";
                row["Age"] = 37;
                PeopleData.Rows.Add(row);
    
                row = PeopleData.NewRow();
                row["Name"] = "Joe";
                row["Age"] = 10;
                PeopleData.Rows.Add(row);
    
                DataContext = this;
            }
    
            public DataTable PeopleData { get; private set;}
    
            private void OnSort(object sender, SelectionChangedEventArgs e)
            {
                if (_sortDirectionsComboBox.SelectedIndex == -1 || _columnsComboBox.SelectedIndex == -1)
                {
                    return;
                }
    
                foreach (DataGridColumn dataColumn in _dataGrid.Columns)
                {
                    dataColumn.SortDirection = null;
                }
    
                ListSortDirection sortDescription = (ListSortDirection)(_sortDirectionsComboBox.SelectedItem);
                DataGridColumn selectedDataColumn = _columnsComboBox.SelectedItem as DataGridColumn;
                selectedDataColumn.SortDirection = sortDescription;
    
                ICollectionView view = CollectionViewSource.GetDefaultView(_dataGrid.ItemsSource);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(selectedDataColumn.Header as string, sortDescription));
                view.Refresh();
            }
        }
    }
