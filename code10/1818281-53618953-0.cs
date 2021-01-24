	public abstract class ABoilerplate {
		public T ConvertTo<T>() where T : class {
			T child = (T)Activator.CreateInstance(typeof(T));
			foreach (System.Reflection.FieldInfo fi in typeof(T).GetFields().Where(field => !field.IsStatic))//should do validations
				fi.SetValue(
					child,
					this.GetType().GetField(fi.Name).GetValue(this));
			return child;
		}
	}
	public class SimpleClass : ABoilerplate {
		public int ID;
	}
	public class DuplicateSimpleClass {
		public int ID;
	}
