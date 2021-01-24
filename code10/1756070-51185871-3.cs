    using ClassLibrary1;
    using EFClassLibrary;
    using System.Windows;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var db = new ClientDbContext();
    
                db.People.Add(new Person()
                {
                    Name = "Omar"
                });
    
                db.SaveChanges();
            }
        }
    }
