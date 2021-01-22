    public class Car
    {
      int m_speed;
      public int Speed { set { m_speed = Math.Max(value, s_maxSpeed; } }
      //static data and static method
      static int s_maxSpeed;
      public static void SetMaxSpeed(int maxSpeed) { s_maxSpeed = maxSpeed; }
    }
