    using System;
    using System.Collections.ObjectModel;
    
    namespace MVVM
    {
    	public class ObservableVMCollectionFactory<TModel, TViewModel>
    		: IVMCollectionFactory<TModel, TViewModel>
    		where TModel : class
    		where TViewModel : class
    	{
    		private readonly IVMFactory<TModel, TViewModel> _factory;
    
    		public ObservableVMCollectionFactory( IVMFactory<TModel, TViewModel> factory )
    		{
    			this._factory = factory.CheckForNull();
    		}
    
    		public ObservableCollection<TViewModel> CreateVMCollectionFrom( ObservableCollection<TModel> models )
    		{
    			Func<TModel, TViewModel> viewModelCreator = model => this._factory.CreateVMFrom(model);
    			return new ObservableVMCollection<TViewModel, TModel>(models, viewModelCreator);
    		}
    	}
    }
