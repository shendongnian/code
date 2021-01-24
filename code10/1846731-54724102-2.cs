    public class TimeoutHandler : IdleStateHandler
    {
        /// <summary>
        /// Initializes a new instance firing <see cref="T:DotNetty.Handlers.Timeout.IdleStateEvent" />s.
        /// </summary>
        /// <param name="readerIdleTimeSeconds">
        ///     an <see cref="T:DotNetty.Handlers.Timeout.IdleStateEvent" /> whose state is <see cref="F:DotNetty.Handlers.Timeout.IdleState.ReaderIdle" />
        ///     will be triggered when no read was performed for the specified
        ///     period of time.  Specify <code>0</code> to disable.
        /// </param>
        /// <param name="writerIdleTimeSeconds">
        ///     an <see cref="T:DotNetty.Handlers.Timeout.IdleStateEvent" /> whose state is <see cref="F:DotNetty.Handlers.Timeout.IdleState.WriterIdle" />
        ///     will be triggered when no write was performed for the specified
        ///     period of time.  Specify <code>0</code> to disable.
        /// </param>
        /// <param name="allIdleTimeSeconds">
        ///     an <see cref="T:DotNetty.Handlers.Timeout.IdleStateEvent" /> whose state is <see cref="F:DotNetty.Handlers.Timeout.IdleState.AllIdle" />
        ///     will be triggered when neither read nor write was performed for
        ///     the specified period of time.  Specify <code>0</code> to disable.
        /// </param>
        public TimeoutHandler(int readerIdleTimeSeconds, int writerIdleTimeSeconds, int allIdleTimeSeconds) : base(readerIdleTimeSeconds, writerIdleTimeSeconds, allIdleTimeSeconds)
        {
        }
        protected override void ChannelIdle(IChannelHandlerContext context, IdleStateEvent stateEvent)
        {
            context.CloseAsync();
        }
    }
