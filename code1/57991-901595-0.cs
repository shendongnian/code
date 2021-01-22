    class Bob {
        
        IWriter _myWriter = null;
        public Bob(){
            // This instance could be injected or you may use a factory
            // Note the initialization logic is here and not in Save method
            _myWriter = new Writer("c://bob.xml")
        }
        //...
        public void Save(){
        
            _myWriter.Write(this);    
        
        }
        // Or...
        public void Save(string where){
        
            _myWriter.Write(this, where);
        
        }
        //...
    }
