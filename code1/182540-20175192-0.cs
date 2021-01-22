            String FullName = "";
            if (BadName != null)
            {
                String[] FullBadName = BadName.Split(' ');
                foreach (string Name in FullBadName)
                {
                    String SmallName = "";
                    if (Name.Length > 1)
                    {
                        SmallName = char.ToUpper(Name[0]) + Name.Substring(1).ToLower();
                    }
                    else
                    {
                        SmallName = Name.ToUpper();
                    }
                    FullName = FullName + " " + SmallName;
                }
            }
            FullName = FullName.Trim();
            FullName = FullName.TrimEnd();
            FullName = FullName.TrimStart();
            return FullName;
        }
