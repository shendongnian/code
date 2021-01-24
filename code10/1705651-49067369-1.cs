    public void Do(){
      this.CallStuff(s => Console.WriteLine(s)); // or you can use a method group and do this.CallStuff(Console.WriteLine);
    }
    
    public void CallStuff(Action<string> action){
      var @string = "fancy!";
      action(@string);
    }
