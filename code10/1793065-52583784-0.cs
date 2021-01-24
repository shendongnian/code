    using System;
    using System.IO;
    using System.Text;
    using System.Resources;
    
    namespace CreateRF
    {
        class CreateRF
        {
            static void Main() 
            {
                string[] lines = File.ReadAllLines(@".\strings.dat", Encoding.UTF8);
                using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
                {
    
                    foreach (string line in lines)
                    {
                        string[] pair = line.Split(',');   
                        resx.AddResource(pair[0], pair[1]);
                    }
                }
            }
        }
    }
