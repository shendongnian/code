    public enum PositionType
    {
        Offensive,
        Defensive,
    }
    
    public class PositionTypeAttribute : Attribute
    {
        public PositionTypeAttribute(PositionType positionType)
        {
            PositionType = positionType;
        }
        public PositionType PositionType { get; private set; }
    }
    
    public enum Position
    {
        [PositionType(PositionType.Offensive)]
        Quarterback,
        [PositionType(PositionType.Offensive)]
        Runningback,
        [PositionType(PositionType.Defensive)]
        DefensiveEnd,
        [PositionType(PositionType.Defensive)]
        Linebacker
    };
    
    public static class PositionHelper
    {
        public static PositionType GetPositionType(this Position position)
        {
            var positionTypeAttr = (PositionTypeAttribute)typeof(Position).GetField(Enum.GetName(typeof(Position), position))
                .GetCustomAttributes(typeof(PositionTypeAttribute), false)[0];
            return positionTypeAttr.PositionType;
    
        }
    }
    
    
    Position position1 = Position.Runningback;
    Console.WriteLine(position1.GetPositionType()); //print: Offensive
    
    Position position2 = Position.Linebacker;
    Console.WriteLine(position2.GetPositionType()); //print: Defensive
