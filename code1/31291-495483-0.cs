    public class TetraQueque : Queue<Tetrablock>
    {
       public new Tetrablock Dequeque()
       {
           return base.Dequeue();
       }
    }
