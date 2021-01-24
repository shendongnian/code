	class __Anonymous1
	{
		private readonly T1 f1 ;
		private readonly T2 f2 ;
		…
		private readonly Tn fn ;
		public __Anonymous1(T1 a1, T2 a2,…, Tn an) {
			f1 = a1 ;
			f2 = a2 ;
			…
			fn = an ;
		}
		public T1 p1 { get { return f1 ; } }
		public T2 p2 { get { return f2 ; } }
		…
		public T1 p1 { get { return f1 ; } }
		public override bool Equals(object o) { … }
		public override int GetHashCode() { … }
	}
