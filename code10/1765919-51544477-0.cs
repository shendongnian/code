    public static probableNode Clone(probableNode pn)
    {
    	probableNode newPn = new probableNode();
    	newPn.Id = pn.Id;
    	newPn.Previd = pn.Previd;
    	newPn.Nextid = new List<int>(pn.Nextid);
    	newPn.X = pn.X;
    	newPn.Y = pn.Y;
    	newPn.Fx = pn.Fx;
        return newPn;
    }
