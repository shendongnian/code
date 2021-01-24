<!-- -->
    using MyProject.Abstractions.Characters;
    using MyProject.Characters;
    namespace MyProject.Abstractions.Visitors
    {
        public interface ICharacterVisitor
        {
            // References MyProject.Characters
            void Visit(Warrior warrior);
            void Visit(Wizard wizard);
        }
    }
