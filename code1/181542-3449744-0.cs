    public class Character
    {
         IWeapenBehavior weapon;
         public Attack()
         {
              weapon.UseWeapon();
         }
    }
    
    
    public class Thief : Character
    {
          Thief()
          {
               weapon = new Knife();
          }
    }
