    Substitutioner sub = new Substitutioner(
        "Hello world <%=Wow%>! My name is <%=Name%>");
    
    MyClass myClass = new MyClass();
    myClass.Wow = 42;
    myClass.Name = "Patrik";
    
    string result = sub.GetResults(myClass);
