public class Character
{
    IWeaponBehavior Weapon;
}
public class Princess : Character
{
    Weapon = new Pan();
}
public class Thief : Character
{
    Weapon = new Knife();
}
