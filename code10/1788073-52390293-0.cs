    ListBox listbox = new ListBox();
	String[] s = new string[] { "5", "2", "3" };
  	listbox.Items.Add(s);
	s = (String[])s.Clone();
	s[2] = "0";
	listbox.Items.Add(s);
	Console.WriteLine(((String[])listbox.Items[0])[2]); // result => 3
	Console.WriteLine(((String[])listbox.Items[1])[2]); // result => 0
	Console.ReadLine();
