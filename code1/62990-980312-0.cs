    Dictionary<string,int> fileCounts = new Dictionary<string, int>();
    using (var sr = new StreamReader("c:\\test.txt",Encoding.Default))
    {
        foreach (var word in sr.ReadLine().ToLower().Split(' '))
    	{
    	    int c = 0;
    	    if (fileCounts.TryGetValue(word, out c))
    	    {
    	        fileCounts[word] = c + 1;
            }
    	    else
    	    {
    	        fileCounts.Add(word, 1);
    	    }					
    	}
    }
    int total = 0;
    foreach (var word in richTextBox1.Text.ToLower().Split(' '))
    {
        int c = 0;
        if (fileCounts.TryGetValue(word, out c))
        {
            total++;
            if (c - 1 > 0)
               fileCounts[word] = c - 1;				
            else
                fileCounts.Remove(word);
        }
    }
    MessageBox.Show(total.ToString());
