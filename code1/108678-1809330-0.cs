    using Retlang.Channels;
    using Retlang.Fibers;
    using Retlang.Core;
    public partial class FooForm: Form 
    {
        PoolFiber _WorkFiber; //backround work fiber
        FormFiber _FormFiber; //this will marshal the messages to the gui thread
        Channel<string> _ServerMessageChannel;
        bool _AbortWork = false;
        public FooForm()
        {
            InitializeComponent();
            _ServerMessageChannel= new Channel<string>();
            _WorkFiber = new PoolFiber();
            _FormFiber = new _Fiber = new FormFiber(this,new BatchAndSingleExecutor());
            _WorkFiber.Start(); //begin recive messages
            _FormFiber .Start(); //begin recive messages
            _WorkFiber.Enqueue(LissenToServer);
            _ServerMessageChannel.Subscribe(_FormFiber,(x)=>textBox1.Text = x);
        }
        private LissenToServer()
        {
             while(_AbortWork == false)
             {
                .... wait for server message
                string mgs = ServerMessage();
                _ServerMessageChannel.Publish(msg);
             }
        }
    }
