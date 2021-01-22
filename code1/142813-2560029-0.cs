    public interface IPresenterProvider
    {
        P Get<P, V>( V view )
            where V : IView
            where P : IPresenter<V>;
    }
    public class PresenterProvider : IPresenterProvider
    {
        private IKernel _kernel;
        public PresenterProvider( IKernel kernel )
        {
            _kernel = kernel;
        }
        #region IPresenterProvider Members
        public P Get<P, V>( V view )
            where P : IPresenter<V>
            where V : IView
        {
            return _kernel.Get<P>( new ConstructorArgument( "view", view ) );
        }
        #endregion
    }
