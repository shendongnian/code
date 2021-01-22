    using System.Collections.ObjectModel;
    
    namespace MVVM
    {
    	public interface IVMCollectionFactory<TModel, TViewModel>
    		where TModel : class
    		where TViewModel : class
    	{
    		ObservableCollection<TViewModel> CreateVMCollectionFrom( ObservableCollection<TModel> models );
    	}
    }
