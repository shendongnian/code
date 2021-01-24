    public class RotationParametersFromStartAndAngle : IRotationParameters
    {
         public float StartingAngle { get; private set; }
         public float EndingAngle { get; private set; }
         public float RotationAngle { get; private set; }   
         public RotationParametersFromStartAndAngle(float start, float angle)
         {
             this.StartingAngle = start;
             this.RotationAngle = angle;
             this.StartingAngle = start + angle;
         } 
    }
