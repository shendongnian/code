    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey key = Registry.LocalMachine;
    
            Traverse(key, 0);
    
            key.Close();
            Console.Read();
            
        }
    
        private static void Traverse(RegistryKey key, int indent)
        {
            Console.WriteLine(key.Name);
            string[] names = key.GetSubKeyNames();
            
    
            foreach (var subkeyname in names)
            {
               
                try
                {
                    string[] valnames = key.GetValueNames();
                    foreach (string valname in valnames)
                    {
                        Console.WriteLine(returnIndentions(indent)+valname + ":" + key.GetValue(valname));
                       
                    }
                    Traverse(key.OpenSubKey(subkeyname),indent++);
                }
                catch { 
                //do nothing
                }
            }
        }
    
        private static string returnIndentions(int indent)
        {
            string indentions = "";
            for (int i = 0; i < indent; i++) {
                indentions += " ";
            }
            return indentions;
        }
    
    }
