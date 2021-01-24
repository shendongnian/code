    namespace Brick
    {
       public partial class MainWindow : Window
       {
          public MainWindow ()
          {
             InitializeComponent ();
             this.DataContext = new View_Model ();
             draw_grid_lines ();
          }
          void draw_grid_lines ()
          {
             var vm = (View_Model)this.DataContext;
             int spaces = vm.grid_size;  // <-- Right here is the problem spot
          }
       }
    }
