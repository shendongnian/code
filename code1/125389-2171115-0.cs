    public interface Player
    {
       void Fight();
       void CastSpell();
       void DoRoguishThings();
    }
    
    public class PlayerImpl : Player
    {
       Player fighter;
       Player wizard;
       Player rogue;
    
       Player current;
    
       public void Fight(){ current.Fight(); }
       public void CastSpell(){ current.CastSpell(); }
       public void DoRoguishThings(){ current.DoRoguishThings; }
       public void MakeWizard(){ current = wizard; }
       public void GoRogue(){ current = rogue; }
    }
    public class Fighter : Player
    {
       public void Fight(){ // do fighting }
       
       public void CastSpell()
       {
          Console.WriteLine("You can't cast a spell, you are but a mere pugilist.");
       }
    
       ...
    }
    
    public class Wizard : Player
    {
       public void Fight(){ // do wizardly fighting }
       public void CastSpell() { // do spell-casting }
       public void DoRoguishThings() { // whatever }
    }
