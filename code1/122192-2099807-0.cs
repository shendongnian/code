    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    interface IMember
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    class Foo : IMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Bar : IMember
    { // explicit, why not...
        int IMember.Id { get; set; }
        string IMember.Name { get; set; } 
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            IMember bar = new Bar();
            bar.Id = 2;
            bar.Name = "def";
            var list = new List<IMember> {
                new Foo { Id = 1, Name = "abc"},
                bar,
            };
            Application.Run(new Form
            {
                Controls = {
                    new ListBox {
                        Dock = DockStyle.Fill,
                        DisplayMember = "Name",
                        ValueMember = "Id",
                        DataSource = list
                    }
                }
            });
            
        }
    }
