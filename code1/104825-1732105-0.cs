    public class MyObject
    {
         public string clan { get; set; }
         public int sifOsoba { get; set; }
         public MyObject(string aClan, int aSif0soba)
         {
            this.clan = aClan;
            this.sif0soba = aSif0soba;
         }
         public override string ToString() { return this.clan; }
     }
     ....
     list.Items.Add(new MyObject("hello", 5));
