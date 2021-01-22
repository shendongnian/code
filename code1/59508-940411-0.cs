    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Equin.ApplicationFramework;
    
    namespace DGVTest
    {
        public interface IListItem
        {
            string Id { get; }
            string Name { get; }
        }
    
        public class User : IListItem
        {
            public string UserSpecificField { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
        }
    
        public class Location : IListItem
        {
            public string LocationSpecificField { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void InitColumns(bool useUsers)
            {
                if (dataGridView1.ColumnCount > 0)
                {
                    return;
                }
    
                DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
    
                DataGridViewTextBoxColumn IDColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn NameColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn DerivedSpecificColumn = new DataGridViewTextBoxColumn();
    
                IDColumn.DataPropertyName = "ID";
                IDColumn.HeaderText = "ID";
                IDColumn.Name = "IDColumn";
                
                NameColumn.DataPropertyName = "Name";
                NameColumn.HeaderText = "Name";
                NameColumn.Name = "NameColumn";
    
                DerivedSpecificColumn.DataPropertyName = useUsers ? "UserSpecificField" : "LocationSpecificField";
                DerivedSpecificColumn.HeaderText = "Derived Specific";
                DerivedSpecificColumn.Name = "DerivedSpecificColumn";
    
                dataGridView1.Columns.AddRange(
                    new DataGridViewColumn[]
                        {
                            IDColumn,
                            NameColumn,
                            DerivedSpecificColumn
                        });
    
                gridViewCellStyle.SelectionBackColor = Color.LightGray;
                gridViewCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.RowsDefaultCellStyle = gridViewCellStyle;
            }
    
            public static void BindGenericList<T>(DataGridView gridView, List<T> list)
            {
                gridView.DataSource = new BindingListView<T>(list);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.AutoGenerateColumns = false;
    
                Random rand = new Random();
    
                bool useUsers = rand.Next(0, 2) == 0;
    
                InitColumns(useUsers);
    
                if(useUsers)
                {
                    TestUsers();
                }
                else
                {
                    TestLocations();
                }
                
            }
    
            private void TestUsers()
            {
                List<IListItem> items =
                    new List<IListItem>
                        {
                            new User {Id = "1", Name = "User1", UserSpecificField = "Test User 1"},
                            new User {Id = "2", Name = "User2", UserSpecificField = "Test User 2"},
                            new User {Id = "3", Name = "User3", UserSpecificField = "Test User 3"},
                            new User {Id = "4", Name = "User4", UserSpecificField = "Test User 4"}
                        };
    
                BindGenericList(dataGridView1, items.ConvertAll(item => (User)item));
            }
    
            private void TestLocations()
            {
                List<IListItem> items =
                    new List<IListItem>
                        {
                            new Location {Id = "1", Name = "Location1", LocationSpecificField = "Test Location 1"},
                            new Location {Id = "2", Name = "Location2", LocationSpecificField = "Test Location 2"},
                            new Location {Id = "3", Name = "Location3", LocationSpecificField = "Test Location 3"},
                            new Location {Id = "4", Name = "Location4", LocationSpecificField = "Test Location 4"}
                        };
    
                BindGenericList(dataGridView1, items.ConvertAll(item => (Location)item));
            }
        }
    }
