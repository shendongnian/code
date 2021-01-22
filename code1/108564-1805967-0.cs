    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    class EngineParameters {
        private bool avoidWeekends;
        public bool AvoidWeekends {
            get { return avoidWeekends; }
            set {
                avoidWeekends = value;
                Debug.WriteLine("AvoidWeekends => " + value);
            }
        }
    }
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();            
            using(Form form = new Form())
            using (CheckBox myCheckbox = new CheckBox()) {
                EngineParameters myEngineParameters = new EngineParameters();
                myEngineParameters.AvoidWeekends = true;    
                form.Controls.Add(myCheckbox);
                myCheckbox.DataBindings.Add("Checked", myEngineParameters, "AvoidWeekends",
                    false, DataSourceUpdateMode.OnPropertyChanged);
                Application.Run(form);
            }
        }
    }
