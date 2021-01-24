       public partial class Title : Page
       {
          public Title()
          {
             InitializeComponent();
             
          }
    public void TitleButtonNext_Click(object sender, EventArgs e)
          {
    
    
           Middle middle = new Middle(); // Navigate to Page 2 on click
           this.NavigationService.Navigate(new Uri("Middle.xaml", UriKind.Relative));
            
    
          }
    }
