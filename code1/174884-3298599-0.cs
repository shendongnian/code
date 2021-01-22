    using System;
    using System.Windows.Forms;
    
    class Test
    {
        [STAThread]
        static void Main()
        {
            Form form = new Form {
                Controls = { 
                    new DateTimePicker {
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "dd/MM/yyyy HH:mm:ss"
                    }
                }
            };
            Application.Run(form);
        }
    }
