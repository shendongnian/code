	public class AetherModelState : ModelState
	{
		public AetherModelState() { }
		public AetherModelState(ModelState state)
		{
			this.AttemptedValue = state.AttemptedValue;
			foreach (var error in state.Errors)
				this.Errors.Add(error);
		}
		private ModelErrorCollection _warnings = new ModelErrorCollection();
		public ModelErrorCollection Warnings { get { return this._warnings; } }
	}
