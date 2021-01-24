    public class ViewModel : ReactiveObject
    {
        private readonly Interaction<string, bool> confirm;
        
        public ViewModel()
        {
            this.confirm = new Interaction<string, bool>();
        }
        
        public Interaction<string, bool> Confirm => this.confirm;
        
        public async Task DeleteFileAsync()
        {
            var fileName = ...;
            
            // this will throw an exception if nothing handles the interaction
            var delete = await this.confirm.Handle(fileName);
            
            if (delete)
            {
                // delete the file
            }
        }
    }
    
    public class View
    {
        public View()
        {
            this.WhenActivated(
                d =>
                {
                    d(this
                        .ViewModel
                        .Confirm
                        .RegisterHandler(
                            async interaction =>
                            {
                                var deleteIt = await this.DisplayAlert(
                                    "Confirm Delete",
                                    $"Are you sure you want to delete '{interaction.Input}'?",
                                    "YES",
                                    "NO");
                                    
                                interaction.SetOutput(deleteIt);
                            }));
                });
        }
    }
