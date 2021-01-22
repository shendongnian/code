    // your reusable MVP framework project 
    public interface IPresenter<P, V> where P : IPresenter<P, V> where V : IView<P, V>
    {
        V View { get; set; }
    }
    public interface IView<P, V> where P : IPresenter<P, V> where V : IView<P, V>
    {
        P Presenter { get; }
    }
    public static class PresenterFactory
    {
        public static P Presenter<P, V>(this IView<P, V> view)
            where P : IPresenter<P, V>, new() where V : IView<P, V>
        {
            return new P { View = (V)view };
        }
    }
 
    // your presentation project
    public interface IEmployeeView : IView<EmployeePresenter, IEmployeeView>
    {
        //...
    }
    public class EmployeePresenter : IPresenter<EmployeePresenter, IEmployeeView>
    {
        //...
    }
 
