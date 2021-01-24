        [Fact]
        public void CanUseInDict()
        {
            var foobar= new Booh();
            IFooBar[] foobars= new IFooBar[]{ foobar.AsIFooBar() };
            Dictionary<IFooBar,string> ifoobars= new Dictionary<IFooBar, string>()
            {
                { foobar.AsIFooBar(), foobar.GetType().Name}
            };
            
            Assert.Equal( foobar.GetHashCode(),  new FooBar<Booh>( foobar ).GetHashCode());
            Assert.True( foobar.AsIFooBar().Equals( new FooBar<Booh>( foobar ) )  , "Equals FooBar<Booh>");
            Assert.True( ifoobars.ContainsKey( new FooBar<Booh>(foobar) ), "ContainsKey");            
            ifoobars.Remove(foobar.AsIFooBar());
            Assert.Empty(ifoobars);
        }
