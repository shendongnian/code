    // keyword 'pattern' marks the code as eligible for inclusion in other classes
    pattern WithFlyBehaviour
    {
       private IFlyBehavior_flyBehavior;
       private void OnReadyToFly()
       {
          _flyBehavior.Fly();
       }
       [patternmethod]
       private void OnReadyToLand()
       {
          _flyBehavior.Land();
       }     
    }
