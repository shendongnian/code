    public class PermanentPassengerSpecification : Specification<Passenger> {
        public override Expression<Func<Passenger, bool>> ToExpression() {
            return passenger => passenger.EmailConfirmed == true;
        }
    }
    
