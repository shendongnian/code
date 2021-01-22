           bool check = false;
           Console.WriteLine("Please Enter the Name");
           name=Console.ReadLine();
           for (int i = 0; i < name.Length; i++)
           {
               if (name[i]>='a' && name[i]<='z' || name[i]==' ')
               {
                   check = true;
               }
               else
               {
                   check = false;
                   break;
               }
 
           }
           if (check==false)
           {
               Console.WriteLine("Enter Valid Value");
               name = Console.ReadLine();
           }
