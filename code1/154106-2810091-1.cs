[Serializable]
public class Host: MarshalByRefObject
{
   private string myHostName;
     
   public string Name{
      get{ return this.myHostName; }
      set{ this.myHostName = value; }
   }
   public Host(string n)
   {
       this.myHostName = n;
   }
   public override string ToString()
   {           
       return this.myHostName;
   }
}
