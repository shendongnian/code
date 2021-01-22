    using System;
    using System.Collections.Generic;
    
    class Program
    {
        private void SetValues()
        {
            var pizzaChoices = new Dictionary<string, double>();
            pizzaChoices.Add("Small", 6.99);
            pizzaChoices.Add("Medium", 8.99);
            pizzaChoices.Add("Large", 11.99);
            comboBox1.DataSource = new BindingSource(pizzaChoices, null); 
            comboBox1.DisplayMember = "Value"; 
            comboBox1.ValueMember = "Key"; 
        }
    }
