    public class EditPage : BasePage<EditController> {
    }
    
    public class EditController : Presenter {
     public EditController(IService service) { }
    }
    
    public class BasePage<T> : Page where T: Presenter
    {
     T Presenter { get; set; }
     public BasePage() { 
      Presenter = ObjectFactory.GetInstance<T>(); //StructureMap
     }
    }
