    public interface IEventRegistrationDiscount(){
    
       <MoneyType> GetDiscountedPrice(EventRegistration registration);
       bool IsApplicable(EventRegistration registration);
    }
    
    public class MembershipDiscount: IEventRegistrationDiscount {
    
    	public MembershipDiscount(int percentage){
    		this.percentage = percentage;
    	}
    	
    	public bool IsApplicable(EventRegistration registration){
    		return registration.User.HasMembership;
    	}
    
        public <MoneyType> GetDiscountedPrice(EventRegistration registration) {
    		if (IsApplicable(registration)){
    			//your real discounting logic here
    			return new MoneyType(registration.Event.Cost*(100-percentage)/100);
    		}
    	}
    }
    
    public class EventRegistrationPricingService
    {
      private IEnumerable<IEventDiscount> discounts;
    
      public EventDiscountService(IEnumerable<IEventDiscount> discounts){
    	  this.discounts = discounts;
      }
      
      public <MoneyType> GetPrice(EventRegistration registration){
          var applicableDiscounts = discounts.Select(x => x.IsApplicable(registration));
    	  var bestDiscount = applicableDiscounts.FirstOrDefault(); 
  
    // if you got many possible discounts then you need to figure out what is the "best" one
        	  //there could be more logic than just discounts
        	  return bestDiscount != null ? bestDiscount.GetDiscountedPrice(registration) : registration.Event.Cost;
          }
        }
