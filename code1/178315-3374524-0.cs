    [TestMethod]
    public void MyMethod() {
       bool success = DoSomething();
       Assert.IsTrue(success);
    }
    public boolean DoSomething(){
        //Do whatever
         
        if(performedOk){
           return true;
        }else{
            //find a way to stop it.
        }
    }
