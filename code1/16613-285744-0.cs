       1: using System.ComponentModel.Composition;
       2: using System.Reflection;
       3: using Microsoft.VisualStudio.TestTools.UnitTesting;
       4:  
       5: namespace MVPwithMEF
       6: {
       7:     /// <summary>
       8:     /// Summary description for MVPTriadFixture
       9:     /// </summary>
      10:     [TestClass]
      11:     public class MVPTriadFixture
      12:     {
      13:         [TestMethod]
      14:         public void MVPTriadShouldBeProperlyBuilt()
      15:         {
      16:             var catalog = new AttributedAssemblyPartCatalog(Assembly.GetExecutingAssembly());
      17:             var container = new CompositionContainer(catalog.CreateResolver());
      18:             var shell = container.GetExportedObject<Shell>();
      19:             Assert.IsNotNull(shell);
      20:             Assert.IsNotNull(shell.Presenter);
      21:             Assert.IsNotNull(shell.Presenter.View);
      22:             Assert.IsNotNull(shell.Presenter.Model);
      23:         }
      24:     }
      25:  
      26:     [Export]
      27:     public class Shell
      28:     {
      29:         private IPresenter _presenter = null;
      30:         
      31:         public IPresenter Presenter
      32:         {
      33:             get { return _presenter; }
      34:         }
      35:  
      36:         [ImportingConstructor]
      37:         public Shell(IPresenter presenter)
      38:         {
      39:             _presenter = presenter;
      40:         }
      41:     }
      42:  
      43:     public interface IModel
      44:     {
      45:     }
      46:  
      47:     [Export(typeof(IModel))]
      48:     public class Model : IModel
      49:     {
      50:         
      51:     }
      52:  
      53:     public interface IView
      54:     {
      55:     }
      56:  
      57:     [Export(typeof(IView))]
      58:     public class View : IView
      59:     {
      60:     }
      61:  
      62:     public interface IPresenter
      63:     {
      64:         IView View { get;}
      65:         IModel Model { get; }
      66:     }
      67:  
      68:     [Export(typeof(IPresenter))]
      69:     public class Presenter : IPresenter
      70:     {
      71:  
      72:         private IView _view;
      73:         private IModel _model;
      74:  
      75:         [ImportingConstructor]
      76:         public Presenter(IView view, IModel model)
      77:         {
      78:             _view = view;
      79:             _model = model;
      80:         }
      81:  
      82:         public IView View
      83:         {
      84:             get { return _view; }
      85:         }
      86:  
      87:         public IModel Model
      88:         {
      89:             get { return _model; }
      90:         }
      91:  
      92:     }
      93: }
