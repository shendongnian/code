        /// <summary>
    	/// A controlled person.  Not production worthy code.
    	/// </summary>
    	public class Person
    	{
    		private string _name;
    		public string Name
    		{
    			get { return _name; }
    			private set
    			{
    				_name = value;
    				OnNameChanged();
    			}
    		}
    		/// <summary>
    		/// This person's controller
    		/// </summary>
    		public PersonController Controller
    		{
    			get { return _controller ?? (_controller = new PersonController(this)); }
    		}
    		private PersonController _controller;
    
    		/// <summary>
    		/// Fires when <seealso cref="Name"/> changes.  Go get the new name yourself.
    		/// </summary>
    		public event EventHandler NameChanged;
    
    		private void OnNameChanged()
    		{
    			if (NameChanged != null)
    				NameChanged(this, EventArgs.Empty);
    		}
    
    		/// <summary>
    		/// A Person controller.
    		/// </summary>
    		public class PersonController
    		{
    			Person _slave;
    			public PersonController(Person slave)
    			{
    				_slave = slave;
    			}
    			/// <summary>
    			/// Sets the name on the controlled person.
    			/// </summary>
    			/// <param name="name">The name to set.</param>
    			public void SetName(string name) { _slave.Name = name; }
    		}
    	}
