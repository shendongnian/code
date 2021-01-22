	public class YourClass {
		public struct SomeTextProperty {
			private readonly YourClass owner;
			internal SomeTextProperty(YourClass owner) {
				this.owner = owner;
			}
			public string this[SomeEnum someEnumThing] {
				get {
					return owner.GetSomeText(someEnumThing);
				}
				set {
					owner.SetSomeText(someEnumThing, value);
				}
			}
		}
		public SomeTextProperty SomeText {
			get {
				return new SomeTextProperty(this);
			}
		}
		private string GetSomeText(SomeEnum someEnumThing) {
			// implementation to get it
		}
		private void SetSomeText(SomeEnum someEnumThing, string value) {
			// implementation to set it
		}
	}
