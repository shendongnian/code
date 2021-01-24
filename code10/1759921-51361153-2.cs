    using System;
    using System.ComponentModel;
    
    namespace ComboBoxInDataGridExample
    {
        public class Shift
        {
            public string Description { get; set; }
            public int ID { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
    
        public class Person
        {
            public int day1_id_ca { get; set; }
            public int day1_f_shift { get; set; }
            public string day1_f_wfh { get; set; }
            public string day1_f_standby { get; set; }
            public int day1_f_edited { get; set; }
            public string day1_note { get; set; }
    
            public BindingList<Shift> Shifts { get; set; }
            public int Shifts_selectedId { get; set; }
    
            public Shift SelectedItem { get { return null; } set { } }
        }
    }
