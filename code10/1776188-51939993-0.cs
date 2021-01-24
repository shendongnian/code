	public class MBDatas<S> : List<S> { }
	
	public class MBData<B, C> where B : MBDatas<C> where C : MBData<B, C> { }
	
	public class Contests : MBDatas<Contest> { }
	
	public class Contest : MBData<Contests, Contest> { }
