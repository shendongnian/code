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
    			SwitchDataSource(); // will just new up the datasource
    		}
    
    		private void ButtonSwitchDataSourceClick(object sender, EventArgs e)
    		{
    			SwitchDataSource();
    		}
    
    		private void SwitchDataSource()
    		{
    			var selectedPeople = (from DataGridViewRow row in dataGridViewPeople.Rows where row.Selected select currentPeople[row.Index]).ToList();
    
    			peopleBindingSource.DataSource = null;
    
    			currentPeople.Clear();
    			if (dummyToggle)
    			{
    				currentPeople.Add(new Person { Name = "Joel Spolsky" });
    				currentPeople.Add(new Person { Name = "Jeff Atwood" });
    				currentPeople.Add(new Person { Name = "Jarrod Dixon" });
    				currentPeople.Add(new Person { Name = "Geoff Dalgas" });
    				currentPeople.Add(new Person { Name = "Brent Ozar" });
    			}
    			else
    			{
    				currentPeople.Add(new Person { Name = "Joel Spolsky" });
    				currentPeople.Add(new Person { Name = "Jeff Atwood" });
    				currentPeople.Add(new Person { Name = "Brent Ozar" });
    			}
    
    			dummyToggle = !dummyToggle;
    
    			peopleBindingSource.DataSource = currentPeople;
    
    			foreach (var person in selectedPeople)
    			{
    				foreach (DataGridViewRow row in dataGridViewPeople.Rows)
    				{
    					if (string.Equals(row.Cells[0].Value, person.Name))
    					{
    						row.Selected = true;
    					}
    				}
    			}
    		}
    	}
    
    	public sealed class Person
    	{
    		public string Name { get; set; }
    	}
    
    }
