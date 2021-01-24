	public class MasterViewModel : ViewModelBase
	{
		public MasterViewModel()
		{
			ChildVM = new ChildVMType();
		}
		private ChildVMType childVM;
		public ChildVMType ChildVM
		{
			get { return childVM; }
			set { SetProperty(ref childVM, value); }
		}
		...
	}
