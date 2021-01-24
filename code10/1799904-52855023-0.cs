    public class YourViewModelDataSource{
    
    private ViewModel viewModel;
    private SecondViewModel secondViewModel;
    public YourViewModelDataSource(ViewModel viewModel, SecondViewModel secondViewModel)
        {
          this.viewModel = viewModel;
          this.secondViewModel = secondViewModel;
        }
    
    public void CreateDataSource()
        {
          this.secondViewModel.PropertyChanged += this.OnSecondViewModelPropertyChanged;
        }
    
    private void OnSecondViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    		{
    			switch (e.PropertyName)
    			{
    				case "SecondProperty":
                        //Here you can raise or you can set ViewModel.myProperty to any value you need
    					this.viewModel.RaisePropertyChanged("myProperty");
    					break;
    			}
    		}
