    StringBuilder sb = new StringBuilder();
    for (int i=0; i< listOfWords.Count; i++)
    {
        sb.AppendFormat("p{0},",i);
        comm.Parameters.AddWithValue("p"+i.ToString(), listOfWords[i]);
    }
    comm.CommandText = string.Format(""SELECT blahblahblah WHERE blahblahblah IN ({0})", 
    sb.ToString().TrimEnd(','));
