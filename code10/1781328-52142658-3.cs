    using System.Threading.Tasks;
    
    namespace App1.Services
    {
        public class SpeechDialogService : ISpeechDialogService
        {
            public async Task ShowAsync()
            {
                var contentDialog = new Speech();
                await contentDialog.ShowAsync();
            }
        }
    }
