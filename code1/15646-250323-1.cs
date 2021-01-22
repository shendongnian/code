   foreach (FileInfo f in files)
   {
       FileInfo f2 = f; //variable declared inside the loop
       Thread t = new Thread(delegate()
       {
            Console.WriteLine(f2.FullName);
       });
       threads.Add(t);
   }
