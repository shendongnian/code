    class Program {
        private readonly IBoardService _boardService;
        private readonly IPlayerService _playerService;
        public Program(IBoardService boardService, IPlayerService playerService) {
            _boardService = boardService;
            _playerService = playerService;
        }
        public void Invoke() {
            var player = _playerService.Create(1, 1);
            var board = _boardService.Create(5, 10, 3, 3, player);
            _boardService.Draw(player, board);
            _boardService.MovePlayer(player, board);
            //...
        }
        static void Main(string[] args) {
            //Assuming default implementations
            IBoardService boardService = new BoardService(); 
            IPlayerService playerService = new PlayerService();
            //Explicit dependency injection via constructor
            var program = new Program(boardService, playerService);
            //invoke desired functionality
            program.Invoke();
            Console.ReadLine();
        }
    }
