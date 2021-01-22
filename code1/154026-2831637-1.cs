    <Button Content="New1" Command="{Binding DataContext.NewTabCommand,ElementName=ControlClass}"/>
 
    namespace Doit_Project.Modules.Tasks.ViewModels
    {
        [Export]
        public class WindoTabViewModel : Doit_ProjectViewModelBase
        {
            public WindoTabViewModel()
            {
    
            }
    
            private RelayCommand _newTabCommand;
            public RelayCommand NewTabCommand
            {
                get { return _newTabCommand ?? (_newTabCommand = new RelayCommand(OnNewTab)); }
            }
    
            public void OnNewTab()
            {
    
            }
        }
    }
