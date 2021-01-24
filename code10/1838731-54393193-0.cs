    void Main()
    {
    	var t1 = new T1[] { new T1(), new T1() };
    	var t2 = new T2[] { new T2(), new T2() };
    	var joinQuery = 
    		from r1 in t1
    		from r2 in t2
    		where r2.ContentsId.Contains(r1.Id) == true
    		select new { name1 = r1.Name, text = r1.Text, name2 = r2.Name };
    }
    
    class T1
    {
    	public int Id { get; set; }
    	public string Name { get; set; } 
    	public string Text { get;set; }
    }
    
    class T2
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int[] ContentsId { get; set; }
    }
