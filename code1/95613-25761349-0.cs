    using System;
    using System.Windows.Forms;
    
    namespace ListView
    {
        public partial class Form1 : Form
        {
            Random rnd = new Random();
            private ListViewColumnSorter lvwColumnSorter;
    
            public Form1()
            {
                InitializeComponent();
                // Create an instance of a ListView column sorter and assign it to the ListView control.
                lvwColumnSorter = new ListViewColumnSorter();
                this.listView1.ListViewItemSorter = lvwColumnSorter;
    
                InitListView();
            }
    
            private void InitListView()
            {
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
    
                //Add column header
                listView1.Columns.Add("Name", 100);
                listView1.Columns.Add("Price", 70);
                listView1.Columns.Add("Trend", 70);
    
                for (int i = 0; i < 10; i++)
                {
                    listView1.Items.Add(AddToList("Name" + i.ToString(), rnd.Next(1, 100).ToString(), rnd.Next(1, 100).ToString()));
                }
            }
    
            private ListViewItem AddToList(string name, string price, string trend)
            {
                string[] array = new string[3];
                array[0] = name;
                array[1] = price;
                array[2] = trend;
    
                return (new ListViewItem(array));
            }
    
            private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
    
                // Perform the sort with these new sort options.
                this.listView1.Sort();
            }
    
        }
    }
  
