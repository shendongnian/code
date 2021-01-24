    public class ColorConsumer<C> where C : struct
    {
        public C InstanceColor { get; set; }
        public ColorConsumer(dynamic color)
        {
           InstanceColor = color;
        }
        //we can move the HandleEnum method here from ColorHandler
       public object HandleEnum()
       {
          int x = (int) InstanceColor + 1;
          return Enum.ToObject(typeof(C), x);
       }
    }
