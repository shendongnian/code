            public static class ProcessPlayers
            {
                public static int ID(Player p)
                {
                    return Convert.ToInt32(p.Id);
                }
    
                public static string Name(Player p)
                {
                    return p.Name.ToString();
                }
            }
