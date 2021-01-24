    public class Pug : Dogs , ThingsDogsDo
    {
        private Ability bark;
        public Pug()
        {
            bark = new Ability();
            bark.cooldown = 2;
        }
    
        public void PugBark()
        {
            if (bark.cooldown == 0)//error occurs on this line
            {
                //He Barks
            }
        }
    }
