     public partial class Final: Page
       {
          public Final()
          {
             InitializeComponent();
             
          }
    public void FinishButtonBack_Click(object sender, EventArgs e)
          {
    
          Middle middle = new Middle(); 
          this.NavigationService.Navigate(middle); //Goes to the previous page
    
          }
      }
