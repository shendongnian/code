public class MoveBehavior: Behavior
{
  private static Dictionary&lt;Mob, int&gt; MovementRateProperty;
  public static void SetMovementRate(Mob theMob, int theRate)
  {
     MovementRateProperty[theMob] = theRate;
  }
  public static int GetMovementRate(Mob theMob)
  {
      // note, you will need handling for cases where it doesn't exist, etc
      return MovementRateProperty[theMob];
  }
}
