    class MyDataContext : DataContext
    {
	   private bool _WorkingFlag = false; // indicates whether we're currently saving
	   private List<object> _UpdateBuffer = new List<object>();
	   // ... other buffers here
	   
	   protected void BeginTransaction()
	   {
		  // implementation
	   }
	   
	   protected void CommitTransaction()
	   {
		  // implementation
	   }
	   public override void SubmitChanges()
	   {
		  BeginTransaction();
		  IList<object> updates = GetChangeSet().Updates;
		  // also inserts and deletes
		  if (_WorkingFlag)
		  {
			 _UpdateBuffer.AddRange(updates);
			 // also inserts and deletes
			 
			 return;
		  }
		  
		  _WorkingFlag = true;
		  updates = updates.Concat(_UpdateBuffer).ToList(); // merge the updates with the buffer
		  foreach (object obj in updates) // do the stuff here...
		  {
			 MyClass mc = obj as MyClass;
			 if (mc != null)
				mc.BeforeUpdate(); // virtual method in MyClass to allow pre-save processing
		  }
		  _UpdateBuffer.Clear(); // clear the buffer
		  
		  // ... same for inserts and deletes ...
		  base.SubmitChanges();
		  
		  // ... after submit, simply foreach ...
		  
		  CommitTransaction();
		  _WorkingFlag = false;
		  
		  // of course all in try... catch, make sure _WorkingFlag is set back to false in the finally block
	   }
    }
