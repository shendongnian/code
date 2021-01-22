    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace infix_to_postfix
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                int i = new int();
                Console.WriteLine("Enter the length of notation:");
    
                //bool extra = new bool();
                //do {
                //    try
                //    {
                        i = Convert.ToInt32(Console.ReadLine());     //enter the length of notation
                    //}
                    //catch
                    //{
                        //Console.WriteLine("Please Get Out");
                //        extra = false;
                        
                //    }
                //} while (extra== false);
    
    
                string[] infix = new string[i];
                string[] postfix = new string[i];
                string[] temp = new string[i];
    
    
    
                Console.WriteLine("Enter values");
                int l = 0;
                for ( l = 0; l < i; l++) 
                {
                    
                    infix[l] = Console.ReadLine();
                }
    
    
                
                int x = 0;
                Console.Write("Infix:");
                for ( x = 0; x < i; x++) 
                {
                    
                    Console.Write( infix[x]);
                }
    
    
    
                //      removing paranthesis
                for(int z=i-1;z>=0;z--)
                {
                    
                    int c = z;
                    if (infix[z] == "(")
                    {
                        infix[z] = null;
                    }
                    if (infix[z] == "+" || infix[z] == "*" || infix[z] == "/" || infix[z] == "-")
                    {
                        do
                        {
                            c++;
                            if (infix[c] == ")")
                            {
                                infix[c] = infix[z];
                                infix[z] = null;
                                break;
                            }
                        }
                        while (c < i) ;
    
    
                    }
    
                }
    
                //filling up
    
                int lagao = 0;
    
                for(int v=0;v<i;v++)
                {
                    if(infix[v]!=null )
                    {
                        postfix[lagao] = infix[v];
                        lagao++;
                    }
                }
    
    
                int p = 0;
                Console.Write("postfix:");
                for (p = 0; p < i; p++)
                {
    
                    Console.Write(postfix[p]);
                }
    
    
    
    
    
    
                //int s = new int();
                //switch(s)
                //{
                //    case 1:
                //        break;
                //    case 2:
                //        break;
                //    case 3:
                //        break;
                //    default:
                //        break;
                //}
    
    
                Console.ReadKey();
            }
          
        }
    }
