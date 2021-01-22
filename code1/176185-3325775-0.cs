            Tetris tetris = new Tetris();
            using (EventAssertion.Raised(tetris, "GameOver").OnlyOnce().Go())
            {
                tetris.Start();
            }
