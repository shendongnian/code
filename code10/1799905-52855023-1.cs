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
                    //As pointed in comments, you need to have the second property in your first ViewModel then do this.
    				case "SecondProperty":
                        this.viewModel.myProperty = this.secondViewModel.SecondProperty;
    					break;
    			}
    		}
