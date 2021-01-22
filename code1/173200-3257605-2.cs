    public class Monster
    {
         public GeneralInfo General {get; set;}
         public SkillsInfo  Skills {get; set;}
    }
    public class GeneralInfo
    {
      public int Hp {get; set;}
      public string Description {get; set;}
      public double TacticModifier {get; set;}
    }
    public class SkillsInfo
    {
      public string[] SkillTypes {get; set;}
    }
