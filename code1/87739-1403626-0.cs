    public partial class Form2 : Form
    {
     .....
     private static Form2 inst;
     public static Form2  GetForm
     {
       get
        {
         if (inst == null || inst.IsDisposed)
             inst = new Form2();
         return inst;
         }
     }
     ....
    }
