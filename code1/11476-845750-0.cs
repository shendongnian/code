    public interface IView
    {
       ...
       event Action SomeEvent;
       event EventHandler Disposed;
       ...
    }
    
    // Note that the IView.Disposed event is implemented by the 
    // UserControl.Disposed event. 
    public class View : UserControl, IView
    {
       public event Action SomeEvent;
    
       public View()
       {
          var presenter = new Presenter(this);
       }
    }
    
    public interface IModel
    {
       ...
       event Action ModelChanged;
       ...
    }
    
    public class Model : IModel
    {
       ...
       public event Action ModelChanged;
       ...
    }
    
    public class Presenter
    {
       private IView MyView;
       private IModel MyModel;
    
       public Presenter(View view)
       {
          MyView = view;
          MyView.SomeEvent += RespondToSomeEvent;
          MyView.Disposed += ViewDisposed;
    
          MyModel = new Model();
          MyModel.ModelChanged += RespondToModelChanged;
       }
    
       // You could take this a step further by implementing IDisposable on the
       // presenter and having View.Dispose() trigger Presenter.Dispose().
       private void ViewDisposed(object sender, EventArgs e)
       {
          MyView.SomeEvent -= RespondToSomeEvent;
          MyView.Disposed -= ViewDisposed;
          MyView = null;
    
          MyModel.Modelchanged -= RespondToModelChanged;
          MyModel = null;
       }
    }
