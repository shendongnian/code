    using System.Windows.Forms;
    public partial class preDownloadXml : Window 
    {
    
        private void CallTheDialog(){
           Microsoft.Win32.SaveFileDialog saveFileDialog = Microsoft.Win32.SaveFileDialog();
           bool? result = saveFileDialog.ShowDialog()
              if(result == true){
                 // to do
              }
        }
    }
