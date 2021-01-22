	public class WeakReference<T> : System.WeakReference
	{
		public WeakReference(T target) : base(target) { }
		public WeakReference(T target, bool trackResurrection) : base(target, trackResurrection) { }
		#if !WindowsCE
		protected WeakReference(SerializationInfo info, StreamingContext context) : base(info, context) {}
		#endif
		public new T Target
		{
			get { return (T)base.Target; }
			set { base.Target = value; }
		}
	}
