    namespace MVVM
    {
    	public interface IVMFactory<TModel, TViewModel>
    	{
    		TViewModel CreateVMFrom( TModel model );
    	}
    }
