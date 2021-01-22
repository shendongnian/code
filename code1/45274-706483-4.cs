        DirectoryEntry root = new DirectoryEntry();
        Traverse(root);
        public static void Traverse(DirectoryEntry root)
        {
            
            if (root.Children != null)
            {
                foreach (DirectoryEntry child in root.Children)
                {
                    Console.WriteLine(child.Username);
                    foreach (string s in child.Properties.PropertyNames)
                        Console.WriteLine("Property {0}: {1}", s, child.Properties[s].Value.ToString());
                    //loop through each Children property unitl I reach the last sub directory
                }
            }
        }
