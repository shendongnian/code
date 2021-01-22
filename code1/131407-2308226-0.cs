    public IEnumerator<Entry> GetEnumerator(){
    	do{
    		self.shouldReset=FALSE;
    		for (Entry e = this.ReadEntry(); e != null; e = this.ReadEntry()){
    			if(self.shouldReset)break;
    			else yield return e;
    		}
    	}
    	while(self.shouldReset)
    }
