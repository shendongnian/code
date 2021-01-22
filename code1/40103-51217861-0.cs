    public enum BusinessUnits
    {
        NEW_EQUIPMENT = 0,
        USED_EQUIPMENT = 1,
        RENTAL_EQUIPMENT = 2,
        PARTS = 3,
        SERVICE = 4,
        OPERATOR_TRAINING = 5
    }
    public class BusinessUnitService
    {
        public static string StringBusinessUnits(BusinessUnits BU)
        {
            switch (BU)
            {
                case BusinessUnits.NEW_EQUIPMENT: return "NEW EQUIPMENT";
                case BusinessUnits.USED_EQUIPMENT: return "USED EQUIPMENT";
                case BusinessUnits.RENTAL_EQUIPMENT: return "RENTAL EQUIPMENT";
                case BusinessUnits.PARTS: return "PARTS";
                case BusinessUnits.SERVICE: return "SERVICE";
                case BusinessUnits.OPERATOR_TRAINING: return "OPERATOR TRAINING";
                default: return String.Empty;
            }
        }
    }
