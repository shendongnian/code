    public partial class FiltrosSisquimView : ContentPage
    {
        public ObservableCollection<Fabricante> Fabricantes { get; set; }
        public FiltrosSisquimView ()
        {              
            InitializeComponent();    
            
            MessagingCenter.Subscribe<Object>(this, "finish", (obj) => {
            var mainViewModel = MainViewModel.GetInstance();
            Fabricantes = mainViewModel.Filtros.Fabricantes;
            mainViewModel.FabricantesModal = new FabricantesModalViewModel(Fabricantes);
            await Application.Current.MainPage.Navigation.PushModalAsync(new FabricantesModalView());
            });
        
        }
        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            //prevents the keyboard from opening when calling the modal
            Make.Unfocus();          
            var mainViewModel = MainViewModel.GetInstance();
            Fabricantes = mainViewModel.Filtros.Fabricantes;
            mainViewModel.FabricantesModal = new FabricantesModalViewModel(Fabricantes);
            await Application.Current.MainPage.Navigation.PushModalAsync(new FabricantesModalView());
        }      
    }
