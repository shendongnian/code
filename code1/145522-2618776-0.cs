    public class AlienMonster
    {
    private List<IAbility> _abilities;
    private List<ILocomotion> _locomotions;
    
    public AlienMonster()
    {
    _abilities = new List<IAbility>() {new Growl()};
    _locomotion = new List<ILocomotion>() {new Walk(), new Run(), new Swim()}
    }
