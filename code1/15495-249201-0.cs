	public class Parent {
		public string Name { get; set; }
		public IList<Child> Children { get { return ChildrenBidi; } set { ChildrenBidi.Set(value); } }
		private BidiChildList<Child, Parent> ChildrenBidi { get {
			return BidiChildList.Create(this, p => p._Children, c => c._Parent, (c, p) => c._Parent = p);
		} }
		internal IList<Child> _Children = new List<Child>();
	}
	public class Child {
		public string Name { get; set; }
		public Parent Parent { get { return ParentBidi.Get(); } set { ParentBidi.Set(value); } }
		private BidiParent<Child, Parent> ParentBidi { get {
			return BidiParent.Create(this, p => p._Children, () => _Parent, p => _Parent = p);
		} }
		internal Parent _Parent = null;
	}
