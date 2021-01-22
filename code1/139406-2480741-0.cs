    public interface IPresenter<P, V> 
        where P : IPresenter<P, V>
        where V : IView<P, V>
    {
    }
    public interface IView<P, V> 
        where P : IPresenter<P, V>
        where V : IView<P, V>
    {
    }
    public class MyView : IView<MyPresenter, MyView>
    {
    }
    public class MyPresenter : IPresenter<MyPresenter, MyView>
    {
    }
