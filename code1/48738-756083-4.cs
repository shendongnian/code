    using System;
    
    namespace ConsoleApplication3
    {
            class Permute
            {
                     private void swap (ref char a, ref char b)
                     {
                            if(a==b)return;
                            a^=b;
                            b^=a;
                            a^=b;
                      }
    
                      public void setper(char[] list)
                      {
                            int x=list.Length-1;
                            go(list,0,x);
                      }
    
                      private void go (char[] list, int k, int m)
                      {
                            int i;
                            if (k == m)
                               {
                                     Console.Write (list);
                                     Console.WriteLine (" ");
                                }
                            else
                                 for (i = k; i <= m; i++)
                                {
                                       swap (ref list[k],ref list[i]);
                                       go (list, k+1, m);
                                       swap (ref list[k],ref list[i]);
                                }
                       }
             }
    
             class Class1
            {
                   static void Main()
                   {
    
                          Permute p = new Permute();
                          string c="sagiv";
                           char []c2=c.ToCharArray ();
                           /*calling the permute*/
                          p.setper(c2);
                      }
               }
    }
