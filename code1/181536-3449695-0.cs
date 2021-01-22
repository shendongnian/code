    Use dependency injection in class Character?
    
    public class Character
    {
    public Character(IWeaponBehavior weapon) {...}
    IWeaponBehavior weapon;
    }
    
    public class Princess
    {
    public Princess(): base(new Pan()) {...}
    }
    
    public class Thief
    {
    public Thief(): base(new Knife()) {...}
    }
