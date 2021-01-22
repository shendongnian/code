    namespace ...
    public partial class NastavaIzvjestaj
    {
       public override bool Equals(object o)
       {
          if (o == null || !(o is NastavaIzvjestaj))
             return false;
    
          return this.Br_idexa == o.Br_idexa;
       }
    
       public override int GetHashCode()
       {
          return this.Br_idexa.GetHashCode();
       }
    }
