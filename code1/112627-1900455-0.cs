	public interface IDescribedModel<T> : IDescribedModel{
		T original {
			get;
		}
	}
	public interface IDescribedEnumerable {
		IDescribedEnumerable<IViewModel> AsIViewModels();
	}
	public interface IDescribedEnumerable<T> : IDescribedEnumerable
		where T : IDescribedModel{
		IEnumerable<T> GetViewModels();
	}
	public class DescribedEnumerable<T> : IDescribedEnumerable<IDescribedModel<T>>{
		public DescribedEnumerable(IEnumerable<T> enumerable) {}
		public IDescribedEnumerable<IViewModel> AsIViewModels() {
			return new GenericDescribedEnumerable<T>(/*allProperties*/);
		}
		public IEnumerable<T> GetViewModels() {
			foreach ( T obj in _enumerable ) {
				var vm = new DescribedModel<T>( obj);
				yield return vm;
			}
		}
	}
	public class GenericDescribedEnumerable<T> : IDescribedEnumerable<IViewModel>{
		//pass in the constructor everything you need, or create in the 
                //constructor of DescribedEnumerable<T>
		public GenericDescribedEnumerable(/*allProperties*/) {
		}
		public IEnumerable<IViewModel> GetViewModels() {
			foreach ( T obj in _enumerable ) {
				var vm = new PlatoViewModel<T>( obj );
				yield return vm;
			}
		}
		public IDescribedEnumerable<IViewModel> AsIViewModels() {
			return this;
		}
	}
