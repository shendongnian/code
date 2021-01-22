	[Fact]
	public void GetRange()
	{
	    IReadOnlyList<int> l = new List<int>() { 0, 10, 20, 30, 40, 50, 60 };
	     l
	        .GetRange(2, 3)
	        .ShouldAllBeEquivalentTo(new[] { 20, 30, 40 });
	     l
	        .GetRange(5, 10)
	        .ShouldAllBeEquivalentTo(new[] { 50, 60 });
	    
	}
	 [Fact]
	void SliceMethodShouldWork()
	{
	    var list = new List<int>() { 1, 3, 5, 7, 9, 11 };
	    list.Slice(1, 4).ShouldBeEquivalentTo(new[] { 3, 5, 7 });
	    list.Slice(1, -2).ShouldBeEquivalentTo(new[] { 3, 5, 7 });
	    list.Slice(1, null).ShouldBeEquivalentTo(new[] { 3, 5, 7, 9, 11 });
	    list.Slice(-2)
	        .Should()
	        .BeEquivalentTo(new[] {9, 11});
	     list.Slice(-2,-1 )
	        .Should()
	        .BeEquivalentTo(new[] {9});
	}
	
