        private static int GetIndex(string name, ArrayList inv)
        {
            for (var i = 0; i < inv.Count; i++) 
            {
                if (((Inventory)inv[i]).Name.Equals(name))
                {
                    return i;
                }
            }
            return -1; 
        }
