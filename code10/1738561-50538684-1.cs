    // class hierarchy
    public abstract class AbstractLogic
    {
        public string DoStufF()
        {
            return DoStufFInternal();
        }
        protected abstract string DoStufFInternal();
    }
    
    // Here 'where' constraint is not essential, I'm just lazy enough
    // and implemented property setting in the dumbest possible way which required the constraint :)
    public abstract class AbstractLogic<T> : AbstractLogic where T: class, new()
    {
        protected AbstractLogic()
        {
            SomeProperty = new T();
        }
        public T SomeProperty { get; private set; }
    }
    
    public class DefaultLogic : AbstractLogic<ClassA>
    {
        protected override string DoStufFInternal()
        {
            return $"Default stuff: SomeProperty = {SomeProperty.ToString()}";
        }
    }
    public class SpecificLogic : AbstractLogic<ClassB>
    {
        protected override string DoStufFInternal()
        {
            return $"Specific stuff: SomeProperty = {SomeProperty.ToString()}";
        }
    }
    public class ClassA
    {
        public override string ToString()
        {
            return "Class A representation";
        }
    }
    public class ClassB
    {
        public override string ToString()
        {
            return "Class B representation";
        }
    }
    // registering class
    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .Where(t => t.Name.StartsWith(Settings.GetCurrentMode().ToString()))
        .As<AbstractLogic>()
        .InstancePerLifetimeScope();
    // and using it in the controller
    [Route("api/[controller]")]
    public class DITestController : Controller
    {
        private readonly AbstractLogic _logic;
        public DITestController(AbstractLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_logic.DoStufF());
        }
    }
