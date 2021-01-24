<!-- -->
    using MyProject.Abstractions.Characters;
    namespace MyProject.Characters
    {
        public abstract class CharacterBase : ICharacter { }
        public class Warrior : CharacterBase { }
        public class Wizard : CharacterBase { }
    }
