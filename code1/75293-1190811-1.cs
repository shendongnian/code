    class ClassA<T> : ICloneable
    {
    	 public string Name { get; set; }
    	 public T ObjectT { get; set; }
    	 
    	 public ClassA<T> Clone()
    	 {
    		 return (ClassA<T>)this.MemberwiseClone();
    	 }
    
    	 object ICloneable.Clone()
    	 {
    		 return this.Clone();
    	 }
    }
