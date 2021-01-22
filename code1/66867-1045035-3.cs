    static class MovementHelper {
      public static SetMovementRate(Mob m, float movementrate){
        MovementBehavior b = m.Get<MovementBehavior();
        if (b != null) {
          b.SetMovementRate(1.20f);
        }
      }
    }
