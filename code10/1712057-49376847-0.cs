    public partial class FileUploadPage : Page {
    
        private async void StartUpload(object sender, RoutedEventArgs e) {
            await UploadFilesAndReport();
        }
        
        private void GoToNewPage(object sender, RoutedEventArgs e) {
            //Pass the current File upload page to NewPage constructor
            var newPage = new NewPage(this);
            this.NavigationService.Navigate(newPage);
        }
    }
    public partial class NewPage : Page
    {
        public NewPage(FileUploadPage fileUploadPage)
        {
            this.fileUploadPage = fileUploadPage;
        }
        private GoBackToFileUploadPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.fileUploadPage);
        }
    }
