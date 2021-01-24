    public class InfoPointingCannotBeSixOurLater : ISpecification<InfoPointing >
    {
        public bool IsSatisfiedBy(InfoPointing infopointing)
        {   
            return DateTime.Now.Subtract(infopointing.Dateregister).TotalHours >=6;
        }
    }
