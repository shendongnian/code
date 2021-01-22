    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class MyCategoryAttribute : CategoryAttribute {
        public MyCategoryAttribute(string categoryKey) : base(categoryKey) { }
    
        protected override string GetLocalizedString(string value) {
            return "Whad'ya know? " + value;
        }
    }
    
    class Person {
        [MyCategory("Personal"), DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
    
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form { Controls = {
               new PropertyGrid { Dock = DockStyle.Fill,
                   SelectedObject = new Person { DateOfBirth = DateTime.Today}
               }}});
        }
    }
