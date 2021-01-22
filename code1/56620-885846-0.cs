    public class CustomerModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            Customer customer = base.BindModel(controllerContext, bindingContext) as Customer;
            if (customer!= null)
            {
                customer.CustomerType= form["CustomerType"];
            }
            
            return customer;
        }
    }
