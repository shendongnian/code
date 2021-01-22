    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void Results_lambdas_match( )
        {
            // Arrange 
            ListController testClass = new ListController( );
            Func<Result> expected = ( ) => new ProductsController( ).ListAction( );
            Result actual;
            byte[ ] actualMethodBytes;
            byte[ ] expectedMethodBytes;
            // Act 
            actual = testClass.DefaultAction( );
            // Assert
            actualMethodBytes = actual.NextAction.
                Method.GetMethodBody( ).GetILAsByteArray( );
            expectedMethodBytes = expected.
                Method.GetMethodBody( ).GetILAsByteArray( );
            // Test that the arrays are the same, more rigorous check really should
            // be done .. but this is an example :)
            for ( int count=0; count < actualMethodBytes.Length; count++ )
            {
                if ( actualMethodBytes[ count ] != expectedMethodBytes[ count ] )
                    throw new AssertFailedException(
                       "Method implementations are not the same" );
            }
        }
        [TestMethod]
        public void Results_lambdas_do_not_match( )
        {
            // Arrange 
            ListController testClass = new ListController( );
            Func<Result> expected = ( ) => new OtherController( ).ListAction( );
            Result actual;
            byte[ ] actualMethodBytes;
            byte[ ] expectedMethodBytes;
            int count=0;
            // Act 
            actual = testClass.DefaultAction( );
            // Assert
            actualMethodBytes = actual.NextAction.
                Method.GetMethodBody( ).GetILAsByteArray( );
            expectedMethodBytes = expected.
                Method.GetMethodBody( ).GetILAsByteArray( );
            // Test that the arrays aren't the same, more checking really should
            // be done .. but this is an example :)
            for ( ; count < actualMethodBytes.Length; count++ )
            {
                if ( actualMethodBytes[ count ] != expectedMethodBytes[ count ] )
                    break;
            }
            if ( ( count + 1 == actualMethodBytes.Length ) 
                && ( actualMethodBytes.Length == expectedMethodBytes.Length ) )
                throw new AssertFailedException(
                    "Method implementations are the same, they should NOT be." );
        }
        public class Result
        {
            public Func<Result> NextAction { get; set; }
        }
        public class ListController
        {
            public Result DefaultAction( )
            {
                Result result = new Result( );
                result.NextAction = ( ) => new ProductsController( ).ListAction( );
                return result;
            }
        }
        public class ProductsController
        {
            public Result ListAction( ) { return null; }
        }
        public class OtherController
        {
            public Result ListAction( ) { return null; }
        }
    }
