     [Fact]
    public void UndoStackSpec()
    {
        var stack = new UndoStack<A>(new A(10, null));
         
        stack.Current().B.Should().Be(null);
         
        stack.Set(x => x.B, new B(20, null));
         
        stack.Current().B.Should().NotBe(null);
        stack.Current().B.P.Should().Be(20);
         
        stack.Undo();
         
        stack.Current().B.Should().Be(null);
     
    }
