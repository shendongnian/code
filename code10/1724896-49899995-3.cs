                 index = -1;
                 for(int j = 0; i < a.Length; j++ )
                 {
                    if (name == a[j])
                    {
                       index = j;
                       break;
                    }
                 }
                 if(index != -1)
                    Console.Write("Student" + name + " is located at" + (index + 1) + " place.");
                 else
                   Console.Write("Student" + name + " is not in list");
