    public interface IOperation
    {
        Guid OperationId { get; }
    }
    
    public interface IOperationTransient : IOperation
    {
    }
    
    public interface IOperationScoped : IOperation
    {
    }
    
    public interface IOperationSingleton : IOperation
    {
    }
    
    public interface IOperationSingletonInstance : IOperation
    {
    }
    
    
    
    
    public class Operation : IOperationTransient, 
        IOperationScoped, 
        IOperationSingleton, 
        IOperationSingletonInstance
    {
        public Operation() : this(Guid.NewGuid())
        {
        }
    
        public Operation(Guid id)
        {
            OperationId = id;
        }
    
        public Guid OperationId { get; private set; }
    }
    
    
    
    
    
    public class OperationService
    {
        public OperationService(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }
    
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }
    }
    
    
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    
        services.AddScoped<IMyDependency, MyDependency>();
        services.AddTransient<IOperationTransient, Operation>();
        services.AddScoped<IOperationScoped, Operation>();
        services.AddSingleton<IOperationSingleton, Operation>();
        services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
    
        // OperationService depends on each of the other Operation types.
        services.AddTransient<OperationService, OperationService>();
    }
    
    
    
    public class IndexModel : PageModel
    {
        private readonly IMyDependency _myDependency;
    
        public IndexModel(
            IMyDependency myDependency, 
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation)
        {
            _myDependency = myDependency;
            OperationService = operationService;
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = singletonInstanceOperation;
        }
    
        public OperationService OperationService { get; }
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }
    
        public async Task OnGetAsync()
        {
            await _myDependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }
    
    
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
    
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
    
                try
                {
                    var serviceContext = services.GetRequiredService<MyScopedService>();
                    // Use the context here
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }
    
            await host.RunAsync();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    
    
    
    ------------
    public class Host
    {
      public static void Main()
      {
        IServiceCollection serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Application application = new Application(serviceCollection);
        // Run
        // ...
      }
      static private void ConfigureServices(IServiceCollection serviceCollection)
      {
        ILoggerFactory loggerFactory = new Logging.LoggerFactory();
        serviceCollection.AddInstance<ILoggerFactory>(loggerFactory);
      }
    }
    public class Application
    {
      public IServiceProvider Services { get; set; }
      public ILogger Logger { get; set; }
        public Application(IServiceCollection serviceCollection)
      {
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();
        Logger = Services.GetRequiredService<ILoggerFactory>()
                .CreateLogger<Application>();
        Logger.LogInformation("Application created successfully.");
      }
      public void MakePayment(PaymentDetails paymentDetails)
      {
        Logger.LogInformation(
          $"Begin making a payment { paymentDetails }");
        IPaymentService paymentService =
          Services.GetRequiredService<IPaymentService>();
        // ...
      }
      private void ConfigureServices(IServiceCollection serviceCollection)
      {
        serviceCollection.AddSingleton<IPaymentService, PaymentService>();
      }
    }
    public class PaymentService: IPaymentService
    {
      public ILogger Logger { get; }
      public PaymentService(ILoggerFactory loggerFactory)
      {
        Logger = loggerFactory?.CreateLogger<PaymentService>();
        if(Logger == null)
        {
          throw new ArgumentNullException(nameof(loggerFactory));
        }
        Logger.LogInformation("PaymentService created");
      }
    }
    
    
    --------
    
    IPaymentService paymentService = Services.GetRequiredService<IPaymentService>()
    ----------
    
    public void Configure(IApplicationBuilder app, IOptions<MyOptions> options)
    {
        ...
    }
    
    --------
    
    public void ConfigureServices(IServiceCollection services)
    {
        ...
    
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    
        ...
    }
    
    -----------
    
    public class IndexModel : PageModel
    {
        private readonly IMyDependency _myDependency;
    
        public IndexModel(
            IMyDependency myDependency, 
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation)
        {
            _myDependency = myDependency;
            OperationService = operationService;
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = singletonInstanceOperation;
        }
    
        public OperationService OperationService { get; }
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }
    
        public async Task OnGetAsync()
        {
            await _myDependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }
    
    
    
    -----------
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    
        services.AddScoped<IMyDependency, MyDependency>();
        services.AddTransient<IOperationTransient, Operation>();
        services.AddScoped<IOperationScoped, Operation>();
        services.AddSingleton<IOperationSingleton, Operation>();
        services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
    
        // OperationService depends on each of the other Operation types.
        services.AddTransient<OperationService, OperationService>();
    }
    
    
    
    -----------------
    
    var services = new ServiceCollection();
    
    services.AddTransient < SauceBearnaise > ();
    
    ServiceProvider container =
     services.BuildServiceProvider(validateScopes: true);
    
    IServiceScope scope = container.CreateScope();
    
    SauceBearnaise sauce = scope.ServiceProvider.GetRequiredService < SauceBearnaise > ();
     
     ILoggingFactory loggingFactor = serviceProvider.GetService<ILoggingFactory>();
    
    
    var services = new ServiceCollection();
    
    services.AddTransient < IIngredient, SauceBearnaise > ();
    
    var container = services.BuildServiceProvider(true);
    
    IServiceScope scope = container.CreateScope();
    
    IIngredient sauce = scope.ServiceProvider
     .GetRequiredService < IIngredient > ();
    
    
    
    object Create(ControllerContext context);
    
    Type controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();
    
    Type controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();
    return scope.ServiceProvider.GetRequiredService(controllerType);
    
    
    services.AddTransient < IIngredient, SauceBearnaise > ();
    
    
    
    services.AddTransient < SauceBearnaise > ();
    services.AddTransient < IIngredient > (
     c => c.GetRequiredService < SauceBearnaise > ());
    
    
    
    
    services.AddTransient < SauceBearnaise > ();
    services.AddTransient < IIngredient > (
     c => c.GetRequiredService < SauceBearnaise > ());
    
    
    
    
    services.AddTransient < SauceBearnaise > ();
    services.AddTransient < IIngredient, SauceBearnaise > ();
    
    
    
    services.AddSingleton < SauceBearnaise > ();
    services.AddSingleton < IIngredient, SauceBearnaise > ();
    
    
    
    services.AddTransient < IIngredient, SauceBearnaise > ();
    services.AddTransient < ICourse, Course > ();
    
    
    
    services.AddTransient < IIngredient, SauceBearnaise > ();
    services.AddTransient < IIngredient, Steak > ();
    
    
    
    Assembly ingredientsAssembly = typeof(Steak).Assembly;
    
    var ingredientTypes =
     from type in ingredientsAssembly.GetTypes()
    where!type.IsAbstract
    where typeof(IIngredient).IsAssignableFrom(type)
    select type;
    
    foreach(var type in ingredientTypes) {
     services.AddTransient(typeof(IIngredient), type);
    }
    
    
    
    
    
    Assembly ingredientsAssembly = typeof(Steak).Assembly;
    
    var ingredientTypes =
     from type in ingredientsAssembly.GetTypes()
    where!type.IsAbstract
    where typeof(IIngredient).IsAssignableFrom(type)
    where type.Name.StartsWith("Sauce")
    select type;
    
    foreach(var type in ingredientTypes) {
     services.AddTransient(typeof(IIngredient), type);
    }
    
    
    
    
    
    
    Assembly policiesAssembly = typeof(DiscountPolicy).Assembly;
    
    var policyTypes =
     from type in policiesAssembly.GetTypes()
    where type.Name.EndsWith("Policy")
    select type;
    
    foreach(var type in policyTypes) {
     services.AddTransient(type.BaseType, type);
    }
    
    
    
    
    public interface ICommandService < TCommand > {
     void Execute(TCommand command);
    }
    
    
    
    public class AdjustInventoryService: ICommandService < AdjustInventory > {
     private readonly IInventoryRepository repository;
    
     public AdjustInventoryService(IInventoryRepository repository) {
      this.repository = repository;
     }
    
     public void Execute(AdjustInventory command) {
      var productId = command.ProductId;
    
      ...
     }
    }
    
    
    
    
    Assembly assembly = typeof(AdjustInventoryService).Assembly;
    
    var mappings =
     from type in assembly.GetTypes()
    where!type.IsAbstract
    where!type.IsGenericType
    from i in type.GetInterfaces()
    where i.IsGenericType
    where i.GetGenericTypeDefinition() ==
     typeof(ICommandService < > )
    select new {
     service = i, type
    };
    
    foreach(var mapping in mappings) {
     services.AddTransient(
      mapping.service,
      mapping.type);
    }
    
    
    
    
    services.AddSingleton < SauceBearnaise > ();
    
    
    
    services.AddSingleton < IIngredient, SauceBearnaise > ();
    
    
    
    
    using(IServiceScope scope = container.CreateScope()) {
     IMeal meal = scope.ServiceProvider
      .GetRequiredService < IMeal > ();
    
     meal.Consume();
    
    }
    
    
    
    
    services.AddScoped < IIngredient, SauceBearnaise > ();
    
    
    
    
    container.Dispose();
    
    
    public enum Spiciness {
     Mild,
     Medium,
     Hot
    }
    
    
    
    services.AddSingleton(
     typeof(Spiciness), Spiciness.Medium);
    
    services.AddTransient < ICourse, ChiliConCarne > ();
    
    
    
    public class Flavoring {
     public readonly Spiciness Spiciness;
     public readonly bool ExtraSalty;
    
     public Flavoring(Spiciness spiciness, bool extraSalty) {
      this.Spiciness = spiciness;
      this.ExtraSalty = extraSalty;
     }
    }
    
    
    
    
    var flavoring = new Flavoring(Spiciness.Medium, extraSalty: true);
    services.AddSingleton < Flavoring > (flavoring);
    
    container.AddTransient < ICourse, ChiliConCarne > ();
    
    
    
    
    services.AddTransient < ICourse > (c => new ChiliConCarne(Spiciness.Hot));
    
    
    
    public static IServiceCollection AddTransient < TService > (
     this IServiceCollection services,
     Func < IServiceProvider, TService > implementationFactory)
    where TService: class;
    
    
    
    
    internal JunkFood(string name)
    
    
    
    public static class JunkFoodFactory {
     public static JunkFood Create(string name) {
      return new JunkFood(name);
     }
    }
    
    
    public ChiliConCarne(Spiciness spiciness)
    
    public enum Spiciness {
     Mild,
     Medium,
     Hot
    }
    
    
    
    services.AddSingleton(
     typeof(Spiciness), Spiciness.Medium);
    
    services.AddTransient < ICourse, ChiliConCarne > ();
    
    
    
    public class Flavoring {
     public readonly Spiciness Spiciness;
     public readonly bool ExtraSalty;
    
     public Flavoring(Spiciness spiciness, bool extraSalty) {
      this.Spiciness = spiciness;
      this.ExtraSalty = extraSalty;
     }
    }
    
    
    
    
    var flavoring = new Flavoring(Spiciness.Medium, extraSalty: true);
    services.AddSingleton < Flavoring > (flavoring);
    
    container.AddTransient < ICourse, ChiliConCarne > ();
    
    
    
    
    
    services.AddTransient < ICourse > (c => new ChiliConCarne(Spiciness.Hot));
    
    
    
    
    public static IServiceCollection AddTransient < TService > (
     this IServiceCollection services,
     Func < IServiceProvider, TService > implementationFactory)
    where TService: class;
    
    
    
    
    internal JunkFood(string name)
    
    
    
    
    public static class JunkFoodFactory {
     public static JunkFood Create(string name) {
      return new JunkFood(name);
     }
    }
    
    
    
    
    
    
    
    
    services.AddTransient < IMeal > (c => JunkFoodFactory.Create("chicken meal"));
    
    
    
    
    services.AddTransient < IIngredient, SauceBearnaise > ();
    services.AddTransient < IIngredient, Steak > ();
    
    
    
    
    
    
    
    IEnumerable < IIngredient > ingredients =
     scope.ServiceProvider.GetServices < IIngredient > ();
    
    
    IEnumerable < IIngredient > ingredients = scope.ServiceProvider
     .GetRequiredService < IEnumerable < IIngredient >> ();
    
    
    
    public ThreeCourseMeal(ICourse entrée, ICourse mainCourse, ICourse dessert)
    
    
    
    
    
    
    
    services.AddTransient < IMeal > (c => new ThreeCourseMeal(
     entrée: c.GetRequiredService < Rillettes > (),
     mainCourse: c.GetRequiredService < CordonBleu > (),
     dessert: c.GetRequiredService < CrèmeBrûlée > ()));
    
    
    
    public ThreeCourseMeal(
     ICourse entrée,
     ICourse mainCourse,
     ICourse dessert,
     ...
    )
    
    
    
    
    services.AddTransient < IMeal > (c =>
     ActivatorUtilities.CreateInstance < ThreeCourseMeal > (
      c,
      new object[] {
       c.GetRequiredService < Rillettes > (),
        c.GetRequiredService < CordonBleu > (),
        c.GetRequiredService < MousseAuChocolat > ()
      }));
    
    
    
    public static T CreateInstance < T > (
     IServiceProvider provider,
     params object[] parameters);
    
    
    
    public Meal(IEnumerable < ICourse > courses)
    
    
    services.AddTransient < ICourse, Rillettes > ();
    services.AddTransient < ICourse, CordonBleu > ();
    services.AddTransient < ICourse, MousseAuChocolat > ();
    
    services.AddTransient < IMeal, Meal > ();
    
    
    
    services.AddScoped < Rillettes > ();
    services.AddTransient < LobsterBisque > ();
    services.AddScoped < CordonBleu > ();
    services.AddScoped < OssoBuco > ();
    services.AddSingleton < MousseAuChocolat > ();
    services.AddTransient < CrèmeBrûlée > ();
    
    services.AddTransient < ICourse > (
     c => c.GetRequiredService < Rillettes > ());
    services.AddTransient < ICourse(
     c => c.GetRequiredService < LobsterBisque > ());
    services.AddTransient < ICourse > (
     c => c.GetRequiredService < CordonBleu > ());
    services.AddTransient < ICourse(
     c => c.GetRequiredService < OssoBuco > ());
    services.AddTransient < ICourse > (
     c => c.GetRequiredService < MousseAuChocolat > ());
    services.AddTransient < ICourse(
     c => c.GetRequiredService < CrèmeBrûlée > ());
    
    services.AddTransient < IMeal > (c = new Meal(
     new ICourse[] {
      c.GetRequiredService < Rillettes > (),
       c.GetRequiredService < CordonBleu > (),
       c.GetRequiredService < MousseAuChocolat > ()
     }));
    
    
    
    
    
    
    services.AddTransient < IIngredient > (c =>
     ActivatorUtilities.CreateInstance < Breading > (
      c,
      ActivatorUtilities
      .CreateInstance < VealCutlet > (c)));
    
    
    
    services.AddTransient < IIngredient > (c =>
     ActivatorUtilities.CreateInstance < Breading > (
      c,
      ActivatorUtilities
      .CreateInstance < HamCheeseGarlic > (
       c,
       ActivatorUtilities
       .CreateInstance < VealCutlet > (c))));
    
    
    
    
    
    
    
    new Breading(
     new HamCheeseGarlic(
      new VealCutlet()));
    
    
    
    Assembly assembly = typeof(AdjustInventoryService).Assembly;
    
    var mappings =
     from type in assembly.GetTypes()
    where!type.IsAbstract
    where!type.IsGenericType
    from i in type.GetInterfaces()
    where i.IsGenericType
    where i.GetGenericTypeDefinition() ==
     typeof(ICommandService < > )
    select new {
     service = i, implementation = type
    };
    
    foreach(var mapping in mappings) {
     Type commandType =
      mapping.service.GetGenericArguments()[0];
    
     Type secureDecoratoryType =
      typeof(SecureCommandServiceDecorator < > )
      .MakeGenericType(commandType);
     Type transactionDecoratorType =
      typeof(TransactionCommandServiceDecorator < > )
      .MakeGenericType(commandType);
     Type auditingDecoratorType =
      typeof(AuditingCommandServiceDecorator < > )
      .MakeGenericType(commandType);
    
     services.AddTransient(mapping.service, c =>
      ActivatorUtilities.CreateInstance(
       c,
       secureDecoratoryType,
       ActivatorUtilities.CreateInstance(
        c,
        transactionDecoratorType,
        ActivatorUtilities.CreateInstance(
         c,
         auditingDecoratorType,
         ActivatorUtilities.CreateInstance(
          c,
          mapping.implementation)))));
    }
    
    
    
    
    
    
    
    public class CompositeNotificationService: INotificationService {
     private readonly IEnumerable < INotificationService > services;
    
     public CompositeNotificationService(
      IEnumerable < INotificationService > services) {
      this.services = services;
     }
    
     public void OrderApproved(Order order) {
      foreach(INotificationService service in this.services) {
       service.OrderApproved(order);
      }
     }
    }
    
    
    
    
    services.AddTransient < OrderApprovedReceiptSender > ();
    services.AddTransient < AccountingNotifier > ();
    services.AddTransient < OrderFulfillment > ();
    
    services.AddTransient < INotificationService > (c =>
     new CompositeNotificationService(
      new INotificationService[] {
       c.GetRequiredService < OrderApprovedReceiptSender > (),
        c.GetRequiredService < AccountingNotifier > (),
        c.GetRequiredService < OrderFulfillment > (),
      }));
    
    
    
    
    Assembly assembly = typeof(OrderFulfillment).Assembly;
    
    Type[] types = (
      from type in assembly.GetTypes() where!type.IsAbstract where typeof(INotificationService).IsAssignableFrom(type) select type)
     .ToArray();
    
    foreach(Type type in types) {
     services.AddTransient(type);
    }
    
    services.AddTransient < INotificationService > (c =>
     new CompositeNotificationService(
      types.Select(t =>
       (INotificationService) c.GetRequiredService(t))
      .ToArray()));
    
    
    
    
    
    Type[] types = (
      from type in assembly.GetTypes() where!type.IsAbstract where typeof(INotificationService)
      .IsAssignableFrom(type) where type != typeof(CompositeNotificationService) select type)
     .ToArray();
    
    
    
    
    Type[] types = (
      from type in assembly.GetTypes() where!type.IsAbstract where typeof(INotificationService).IsAssignableFrom(type) where type != typeof(CompositeNotificationService) where type => !IsDecoratorFor < INotificationService > (type) select type)
     .ToArray();
    
    
    
    
    
    
    private static bool IsDecoratorFor < T > (Type type) {
     return typeof(T).IsAssignableFrom(type) &&
      type.GetConstructors()[0].GetParameters()
      .Any(p => p.ParameterType == typeof(T));
    }
    
    
    
    
    
    public class CompositeSettings {
     public Type[] AllHandlerTypes {
      get;
      set;
     }
    }
    
    public class CompositeEventHandler < TEvent >
     : IEventHandler < TEvent > {
      private readonly IServiceProvider provider;
      private readonly CompositeSettings settings;
    
      public CompositeEventHandler(
       IServiceProvider provider,
       CompositeSettings settings) {
       this.provider = provider;
       this.settings = settings;
      }
    
      public void Handle(TEvent e) {
       foreach(var handler in this.GetHandlers()) {
        handler.Handle(e);
       }
      }
    
      IEnumerable < IEventHandler < TEvent >> GetHandlers() {
       return
       from type in this.settings.AllHandlerTypes
       where typeof(IEventHandler < TEvent > )
       .IsAssignableFrom(type)
       select(IEventHandler < TEvent > )
       ActivatorUtilities.CreateInstance(
        this.provider, type);
      }
     }
    
    
    
    
    
    
    var handlerTypes =
     from type in assembly.GetTypes()
    where!type.IsAbstract
    where!type.IsGenericType
    let serviceTypes = type.GetInterfaces()
     .Where(i => i.IsGenericType &&
      i.GetGenericTypeDefinition() ==
      typeof(IEventHandler < > ))
    where serviceTypes.Any()
    select type;
    
    services.AddSingleton(new CompositeSettings {
     AllHandlerTypes = handlerTypes.ToArray()
    });
    
    services.AddTransient(
     typeof(IEventHandler < > ),
     typeof(CompositeEventHandler < > ));
