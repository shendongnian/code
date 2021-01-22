    // Begin personalization assembly (one of many)-----------------------
    
    /// <summary>
    /// Here you could use an attribute to allow clean reflection
    /// </summary>
    // [CustomerSpecific("Acme")]
    public class AcmeCustomization : BaseCustomization
    {
        public override void OnStatusChanged()
        {
            base.OnStatusChanged();
            // do what you need to customize
        }
    }
    // End personalization assembly (one of them)-------------------------
    
    // Begin core assembly -----------------------------------------------
    public interface ICustomization
    {
        void OnStatusChanged();
    }
    
    /// <summary>
    /// This class is optional of course, but can be useful
    /// </summary>
    public class BaseCustomization : ICustomization
    {
        public virtual void OnStatusChanged()
        {
            // intentionally empty
        }
    }
    
    class CustomizationFactory
    {
        public ICustomization GetCustomization(string order)
        {
            // Here you could
            // - hardcode (as you did in your solution)
            // - use reflection (various ways)
            // - use an external mapping file
            // - use MEF (!)
            // and then
            // - do instance caching
            // - whatever...
            // I'm lazy ;-)
            return null;
        }
    }
    
    class OrderManager
    {
        private ICustomization _customization = null;
    
        public void SetStatus(string order, int status)
        {
            // Do some work
            this.OnStatusChanged();
            // Do some other work
        }
    
        protected void OnStatusChanged()
        {
            if (_customization != null)
            {
                _customization.OnStatusChanged();
            }
        }
    
        public void SetCustomization(ICustomization customization)
        {
            _customization = customization;
        }
    
        public void ClearCustomization()
        {
            _customization = null;
        }
    }
    // End core assembly -------------------------------------------------
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomizationFactory factory = new CustomizationFactory();
            OrderManager manager = new OrderManager();
    
            // here I'm just pretending to have "orders"
            var orders = new string[] { 
                "abc",
                "def"
            };
    
            const int newStatus = 42;
    
            foreach (var order in orders)
            {
                manager.SetCustomization(factory.GetCustomization(order));
                manager.SetStatus(order, newStatus);
                manager.ClearCustomization();
            }
        }
    }
