    using System.Collections.Generic;
    using System.Windows;
    
    namespace testtestz
    { 
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<object> myData = new List<object>()
                {
                    new { Id = 1, Name = "John" },
                    new { Id = 2, Name = "Mary" },
                    new { Id = 3, Name = "Anna" },
                };
    
                GridViews.Add(new MyGrid { Data = myData});
                GridViews.Add(new MyGrid { Data = myData });
                GridViews.Add(new MyGrid { Data = myData });
    
                DataContext = this;
            }
    
            public List<MyGrid> GridViews { get; } = new List<MyGrid>();
        }
    
        public class MyGrid
        {
            public IEnumerable<object> Data { get; set; }
        }
    }
