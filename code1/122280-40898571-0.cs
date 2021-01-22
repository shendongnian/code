        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.DirectoryServices.AccountManagement;
    
    namespace ExportActiveDirectoryGroupsUsers
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args == null)
                {
                    Console.WriteLine("args is null, useage: ExportActiveDirectoryGroupsUsers OutputPath"); // Check for null array
                }
                else
                {
                    Console.Write("args length is ");
                    Console.WriteLine(args.Length); // Write array length
                    for (int i = 0; i < args.Length; i++) // Loop through array
                    {
                        string argument = args[i];
                        Console.Write("args index ");
                        Console.Write(i); // Write index
                        Console.Write(" is [");
                        Console.Write(argument); // Write string
                        Console.WriteLine("]");
                    }
                    try
                    {
                        using (var ServerContext = new PrincipalContext(ContextType.Domain, ServerAddress, Username, Password))
                        {
                            /// define a "query-by-example" principal - here, we search for a GroupPrincipal 
                            GroupPrincipal qbeGroup = new GroupPrincipal(ServerContext, args[0]);
    
                            // create your principal searcher passing in the QBE principal    
                            PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);
    
                            // find all matches
                            foreach (var found in srch.FindAll())
                            {
                                GroupPrincipal foundGroup = found as GroupPrincipal;
    
                                if (foundGroup != null)
                                {
                                    // iterate over members
                                    foreach (Principal p in foundGroup.GetMembers())
                                    {
                                        Console.WriteLine("{0}|{1}", foundGroup.Name, p.DisplayName);
                                        // do whatever you need to do to those members
                                    }
                                }
    
                            }
                        }
                        //Console.WriteLine("end");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something wrong happened in the AD Query module: " + ex.ToString());
                    }
                    Console.ReadLine();
                }
            }
        }
    }
