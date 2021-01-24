    private async void Entry_Focused(object sender, FocusEventArgs e)
    {
      Normal.Unfocus(); 
      //prevents the keyboard from opening when calling the modal
      Make.Unfocus();          
      var mainViewModel = MainViewModel.GetInstance();
      Fabricantes = mainViewModel.Filtros.Fabricantes;
      mainViewModel.FabricantesModal = new FabricantesModalViewModel(Fabricantes);
      await Application.Current.MainPage.Navigation.PushModalAsync(new FabricantesModalView());
    }
