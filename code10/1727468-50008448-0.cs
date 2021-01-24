        public void Method2()
        {
        //This method only adds new entities
         var entity = new SomeEntity();
         repo.Add(entity);
        }
    
        public void Method3()
        {
         //This method only updates entities
         var anotherEntity= new AnotherEntity();
         repo.Update(anotherEntity);
        }
