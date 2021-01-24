        void Main()
        {
        	bool first = true;
        	bool second = false;
        	if(first){
        		second = true;
        		Console.WriteLine("One true");
        	}else if(second){
        		Console.WriteLine("Two trues");
        	}else{
                //more like default, but you don't see this which is what matters
        		Console.WriteLine("Three trues");
        	}
        }
    
    //Result:  One True
