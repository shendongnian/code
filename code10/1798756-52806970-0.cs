     public void RemoveDuplicates()
     {
          set = new HashSet<MerkmalRow>(Merkmalls);
          Merkmalls = set.ToList();
     }
