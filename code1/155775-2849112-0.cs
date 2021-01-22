    static class Program
    	{
    		private delegate Foo Delegate1();
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			MethodInfo mi = typeof(Bar<>).GetMethod("GetClass", BindingFlags.NonPublic | BindingFlags.Static);
    			if (mi != null)
    			{
    				var del = (Delegate1)Delegate.CreateDelegate(typeof(Delegate1), mi);
    
    				MessageBox.Show("1");
    				try
    				{
    					del();
    					//mi.Invoke(null, BindingFlags.NonPublic | BindingFlags.Static, null, null,CultureInfo.InvariantCulture);
    				}
    				catch (Exception)
    				{
    					MessageBox.Show("No, I can`t catch it");
    				}
    				MessageBox.Show("2");
    				mi.Invoke(null, new object[] { });//It's Ok, we'll get exception here
    				MessageBox.Show("3");
    			}
    		}
    		class Foo
    		{
    
    		}
    		class Bar<T> : Foo
    		{
    			internal static Foo GetClass()
    			{
    				Type type = typeof(T);
    				MessageBox.Show("Type name " + type.FullName + " Type: " + type + " Assembly " + type.Assembly);
    				return new Bar<T>();
    			}
    		}
    	}
