    public class RotationParametersFromStartAndEnd : IRotationParameters
    {
         public float StartingAngle { get; private set; }
         public float EndingAngle { get; private set; }
         public float RotationAngle { get; private set; }   
         public RotationParametersFromStartAndEnd (float start, float end)
         {
             this.StartingAngle = start;
             this.StartingAngle = end;
             this.RotationAngle = end - start;
         } 
    }
