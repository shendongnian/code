     public partial class Middle: Page
       {
          public Middle()
          {
             InitializeComponent();
             
          }
    public void MiddleButtonNext_Click(object sender, EventArgs e)
          {
    
    
           Final final = new Final(); // Navigate to Page 3 on click
           this.NavigationService.Navigate(new Uri("Final.xaml", UriKind.Relative));
            
    
          }
      }
