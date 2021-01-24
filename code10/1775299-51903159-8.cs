    public class SomeClass
    {
        public static void Main(string [] args)
        {
            Model model = new Model();
            ViewModel viewModel = new ViewModel(model);
    
            //Now setting the viewmodel.Test will update the model property
            viewModel.Test = "This is a test";
        }
    }
