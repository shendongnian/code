        namespace Proof_of_Concept_2
        {
            class Program
            {
                static void Main(string[] args)
                {
                    if (args.Length!= 0)
                    {
                        if (args[0] == "1")
                        {
                            AlternatePathOfExecution();
                        }
                        //add other options here and below              
                    }
                    else
                    {
                        NormalPathOfExectution();
                    }
                }
                private static void NormalPathOfExectution()
                {
                    Console.WriteLine("Doing something here");
                    //need one of these for each additional console window
                    System.Diagnostics.Process.Start("Proof of Concept 2.exe", "1");
                    Console.ReadLine();
                }
                private static void AlternatePathOfExecution()
                {
                    Console.WriteLine("Write something different on other Console");
                    Console.ReadLine();
                }
            }
        }
