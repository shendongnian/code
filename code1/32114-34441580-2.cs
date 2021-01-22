        /// <summary>
        /// Interface to implement for classes visitable by a visitor.
        /// See Visitor design pattern for more details.
        /// </summary>
        /// <typeparam name="TVisitor">The type of the visitor.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        public interface IVisitable<TVisitor, TResult> : IVisitable where TVisitor : IVisitor
        {
            TResult Accept(TVisitor visitor);
        }
    
        /// <summary>
        /// Marking interface.
        /// </summary>
        public interface IVisitable {}
    
