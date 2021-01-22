    public interface ITargetAdapter
    {
        void Open();
        void Close();
    }
    public class AdapterA : ITargetAdapter
    {
         private TargetA A { get; set; }
         public AdapterA( TargetA a )
         {
               this.A = a;
         }
         public void Open() { this.A.Start(); }
         public void Close() { this.A.End(); }
    }
    public class AdapterB : ITargetAdapter
    {
         private TargetB B { get; set; }
         public AdapterB( TargetB a )
         {
               this.B = a;
         }
         public void Open() { this.B.Begin(); }
         public void Close() { this.B.Terminate(); }
    }
