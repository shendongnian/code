    class Druid : Character
    {
       // many cool druid skills and spells
       virtual void LightHeal(Character target) { }
    }
    abstract class CharacterDecorator : Character
    {
        Character DecoratedCharacter;
    }
    
    class CheetahForm : CharacterDecorator
    {
        Character DecoratedCharacter;
        public CheetahDecorator(Character decoratedCharacter)
        {
           DecoratedCharacter= decoratedCharacter;
        }
    
        // many cool cheetah related skills
        void CheetahRun()
        {
           // let player move very fast
        }
    
        override void LightHeal(Character target)
        {
            ShowPlayerMessage("You cannot do that while shape shifted.");
        }
    }
