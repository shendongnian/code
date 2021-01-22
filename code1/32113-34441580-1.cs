        /// <summary>
        /// Interface to implement for classes visiting others. 
        /// See Visitor design pattern for more details.
        /// </summary>
        /// <typeparam name="TVisited">The type of the visited.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        public interface IVisitor<TVisited, TResult> : IVisitor where TVisited : IVisitable
        {
            TResult Visit(TVisited visited);
        }
    
        /// <summary>
        /// Marking interface.
        /// </summary>
        public interface IVisitor{}
