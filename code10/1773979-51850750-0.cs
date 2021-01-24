    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public interface IAnimal
            {
                string Name { get; set; }
                //Type GetType();
            }
    
            public class Dog : IAnimal
            {
                public string Name { get; set; }
                //new Type GetType() { return typeof(Dog); }
                public int TimesBarked { get; set; }
            }
    
            public class Rhino : IAnimal
            {
                public string Name { get; set; }
                //new Type GetType() { return typeof(Rhino); }
                public bool HasHorn { get; set; }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                IAnimal animal1 = new Dog { Name = "Ben", TimesBarked = 30 };
                IAnimal animal2 = new Rhino { Name = "James" };
    
                MessageBox.Show($"GetType : {animal1.GetType()}");
    
                PeopleWillTellYouToNotDoThis(animal1);
                PeopleWillTellYouToNotDoThis(animal2);
            }
    
            private void PeopleWillTellYouToNotDoThis(dynamic inAnimal)
            {
                MessageBox.Show($"GetType : {inAnimal.GetType()}");
            }
        }
    }
