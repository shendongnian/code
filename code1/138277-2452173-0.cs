    public class ServiceLayer
    {
       public void SaveModel(ViewModel viewmodel)
       {
          var model = viewModel.ToModel();
          repository.Save(model)
       }
    }
