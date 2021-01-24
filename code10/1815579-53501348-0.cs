    using(StreamWriter SW = new StreamWriter("important.txt"))
    {
            foreach(Emplooye i in group1)
            {
    
                SW.WriteLine(group1.ToString());
			}
               foreach(Emplooye i in group2)
            {
    
                SW.WriteLine(group2.ToString());
            } 
                foreach(Emplooye i in group3)
            {
    
                SW.WriteLine(group3.ToString());
    
    
    
			}
    }
