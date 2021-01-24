            // A simple customer class that implements the interface
            public class Customer : IExpressionKeyEntity
            {
                // An id property that we don't know anything about from the outside
                public int CustomerId { get; set; }
                // A func that takes an id and returns true if it's a match against this entities id
                public Func<int, bool> HasMatchingId => comparisonEntityId => comparisonEntityId == CustomerId;
            }
