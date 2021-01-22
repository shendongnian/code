    public interface ICanAttack { void Attack(Character attackee); }
    public class Character { ... }
    public class Warrior : Character, ICanAttack 
    {
        public void Attack(Character attackee) { CharacterUtils.Attack(this, attackee); }
    }
    public static class CharacterUtils 
    {
        public static void Attack(Character attacker, Character attackee) { ... }
    }
