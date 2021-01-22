    //Some types we'll need
       enum Jobs
       {
          Programmer,
          Salesman
       }
    
       enum DrinkCode
       {
          Coffee,
          Coke,
          MountainDew,
          GinAndTonic
       }
    
       internal class Drink
       {
          public DrinkCode Code { get; set; }
          public string Name { get; set; }
          public bool Caffeinated { get; set; }
          public bool Alcoholic { get; set; }
       }
    
       internal class Person
       {
          public string Name { get; set; }
    
          public Jobs Job { get; set; }
    
          public DrinkCode Drink { get; set; }
       }
    // the form class
    public partial class Form1 : Form
    {
      public Form1()
      {
         InitializeComponent();
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         BindingSource bindingSource = new BindingSource();
         bindingSource.DataSource = FindPersons();
         this.dataGridView1.DataSource = bindingSource;
         DataGridViewComboBoxColumn column =
             new DataGridViewComboBoxColumn();
         {
            column.DataPropertyName = "Drink";
            column.HeaderText = "beverage";
            column.DisplayMember = "Name";
            column.ValueMember = "Code";
            column.DataSource = BuildDrinksList();
         }
         dataGridView1.Columns.Add(column);
         //handling this event is the nub of the solution
         dataGridView1.EditingControlShowing += 
            new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
      }
      void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
         //When the focus goes into the combo box cell, we can update the contents of the dropdown
         // 
         DataGridViewComboBoxEditingControl comboBox = e.Control as DataGridViewComboBoxEditingControl;
         //if you have more than one drop down this is not going to be good enough, but hey, it's an example!
         if (comboBox != null)
         {
            BindingSource bindingSource = this.dataGridView1.DataSource as BindingSource;
            Person person = bindingSource.Current as Person;
            BindingList<Drink> bindingList = this.BuildDrinksList(person);
            comboBox.DataSource = bindingList;
         }
      }
      //the rest of this is just data to make the example work
      private BindingList<Drink> BuildDrinksList()
      {
         var drinks = new BindingList<Drink>();
         drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.Coffee, Name = "Coffee" });
         drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.Coke, Name = "Coke" });
         drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.MountainDew, Name = "Mountain Dew" });
         drinks.Add(new Drink() { Alcoholic = true, Caffeinated = false, Code = DrinkCode.GinAndTonic, Name = "Gin and Tonic" });
         
         return drinks;
      }
      
      private BindingList<Drink> BuildDrinksList(Person p)
      {
         var drinks = new BindingList<Drink>();
         if (p.Job == Jobs.Programmer)
         {
            drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.Coffee, Name = "Coffee" });
            drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.Coke, Name = "Coke" });
            drinks.Add(new Drink() { Alcoholic = false, Caffeinated = true, Code = DrinkCode.MountainDew, Name = "Mountain Dew" });
         }
         if (p.Job == Jobs.Salesman)
         {
            drinks.Add(new Drink() { Alcoholic = true, Caffeinated = false, Code = DrinkCode.GinAndTonic, Name = "Gin and Tonic" });
         }
         return drinks;
      }
      private BindingList<Person> FindPersons()
      {
         BindingList<Person> bindingList = new BindingList<Person>();
         bindingList.Add(new Person() { Job = Jobs.Programmer, Drink = DrinkCode.Coffee, Name = "steve" });
         bindingList.Add(new Person() { Job = Jobs.Salesman, Drink = DrinkCode.GinAndTonic, Name = "john" });
         return bindingList;
      }
   }
