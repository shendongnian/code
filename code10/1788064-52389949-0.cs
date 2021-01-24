    static void Main(string[] args)
    {
      ListBox listbox = new ListBox();
      String[] s = new string[] { "5", "2", "3" };
      foreach(var item in s)
      {
       listbox.Items.Add(item);
      }
       Console.WriteLine(((String[])listbox.Items[0])[2]); // result => 0
       Console.WriteLine(((String[])listbox.Items[1])[2]); // result => 0
       Console.ReadLine();
     }
