      static void Main(string[] args)
       {
        ListBox listbox = new ListBox();
        String[] s = new string[] { "5", "2", "3" };
        listbox.Items.Add(s);
        String[] s2 = new string[] { "5", "2", "0" };
        listbox.Items.Add(s2);
    
        Console.WriteLine(((String[])listbox.Items[0])[2]); // result => 0
        Console.WriteLine(((String[])listbox.Items[1])[2]); // result => 0
        Console.ReadLine();
       }
