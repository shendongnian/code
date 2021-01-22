    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace DataGridViewRetainSelection
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private readonly List<Person> currentPeople = new List<Person>();
    		private bool dummyToggle = true;
    
    		private void Form1_Load(object sender, EventArgs e)
    		{
    			dataGridViewPeople.SelectionMode = DataGridViewSelectionMode.CellSelect;
    			SwitchDataSource(); // will just new up the datasource
    		}
    
    		private void ButtonSwitchDataSourceClick(object sender, EventArgs e)
    		{
    			SwitchDataSource();
    		}
    
    		private void SwitchDataSource()
    		{
    			var selectedPeopleAndCells = (from DataGridViewCell cell in dataGridViewPeople.SelectedCells where cell.Selected select new { Person = currentPeople[cell.RowIndex], Cell = cell }).ToList();
    
    			peopleBindingSource.DataSource = null;
    
    			currentPeople.Clear();
    			if (dummyToggle)
    			{
    				currentPeople.Add(new Person { Name = "Joel Spolsky", Id = 0 });
    				currentPeople.Add(new Person { Name = "Jeff Atwood", Id = 1 });
    				currentPeople.Add(new Person { Name = "Jarrod Dixon", Id = 2 });
    				currentPeople.Add(new Person { Name = "Geoff Dalgas", Id = 3 });
    				currentPeople.Add(new Person { Name = "Brent Ozar", Id = 4 });
    			}
    			else
    			{
    				currentPeople.Add(new Person { Name = "Joel Spolsky", Id = 0 });
    				currentPeople.Add(new Person { Name = "Jeff Atwood", Id = 1 });
    				currentPeople.Add(new Person { Name = "Brent Ozar", Id = 4 });
    			}
    
    			dummyToggle = !dummyToggle;
    
    			peopleBindingSource.DataSource = currentPeople;
    
    			foreach (var personAndCell in selectedPeopleAndCells)
    			{
    				foreach (DataGridViewRow row in dataGridViewPeople.Rows)
    				{
    					if (string.Equals(row.Cells[0].Value, personAndCell.Person.Id))
    					{
    						row.Cells[personAndCell.Cell.ColumnIndex].Selected = true;
    					}
    				}
    			}
    		}
    	}
    
    	public sealed class Person
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    	}
    
    }
