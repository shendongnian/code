    namespace Mod1_SelfAssesment
    {
    public class UniProgram
    {
      public string Programme { get; set; }
      public IList<Degree> Degrees {get;set;}
    public UniProgram(string programme)
    {
        this.Programme = programme;
        Degrees = new List<Degree>();
    }
     namespace Mod1_SelfAssesment
     {
       public class Degree
       {
        public string _Degree { get; set; }
        public Degree(string degree)
        {
            this._Degree = degree;
        }
       }
      }
