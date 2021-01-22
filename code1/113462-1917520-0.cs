    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            Form f = new Form
            {
                Controls =
                {
                    new CheckedListBox
                    {
                        Items = 
                        {
                            new { FirstName = "Jon", LastName = "Skeet" },
                            new { FirstName = "Holly", LastName = "Skeet" }
                        },
                        DisplayMember = "FirstName"
                    }
                }
            };
            Application.Run(f);
        }
    }
