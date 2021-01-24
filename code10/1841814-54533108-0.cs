    public class Cat
    {
        /// <summary>
        /// Amount of collected coder souls.
        /// </summary>
        private int _coderSouls;
        /// <summary>
        /// Amount of collected food.
        /// </summary>
        private int _food;
        /// <summary>
        /// Amount of deadlocks collected.
        /// </summary>
        private int _deadlocks;
        /// <summary>
        /// Number of jumps before deadlocking.
        /// Starts from -1 because When we set the path
        /// The kitty starts from the 0th tile.
        /// </summary>
        private int _numberOfJumps = -1;
        /// <summary>
        /// If Cat can still move.
        /// </summary>
        private bool _deadLocked;
        /// <summary>
        /// Path to follow.
        /// </summary>
        private Path _path;
        /// <summary>
        /// Creates a Kitty
        /// </summary>
        /// <param name="path">Path for Kitty</param>
        public Cat(Path path)
        {
            SetPath(path);
        }
        /// <summary>
        /// Set the path for Kitty to follow.
        /// </summary>
        /// <param name="path">Path to follow.</param>
        private void SetPath(Path path)
        {
            _path = path;
            Walk(0);
        }
        /// <summary>
        /// Walks the Kitty with the given amount of steps.
        /// </summary>
        /// <param name="step">Amount of steps</param>
        /// <returns>If kitty can move any more.</returns>
        public bool Walk(int step)
        {
            // If Kitty is deadlocked it can not move any more
            if (_deadLocked)
            {
                return false;
            }
            // Walks the cat with the given step amount
            var got = _path.MoveToNext(step);
            // Increase the number of Jumps
            _numberOfJumps++;
            // Rule written in the question
            switch (got)
            {
                case ItemType.CoderSoul:
                    _coderSouls++;
                    break;
                case ItemType.Food:
                    _food++;
                    break;
                case ItemType.DeadLock:
                    _deadlocks++;
                    var isEven = _path.GetPosition() % 2 == 0;
                    if (isEven)
                    {
                        if (_coderSouls > 0)
                        {
                            _coderSouls--;
                            return true;
                        }
                        _deadLocked = true;
                        return false;
                    }
                    if (_food > 0)
                    {
                        _food--;
                        return true;
                    }
                    _deadLocked = true;
                    return false;
            }
            return true;
        }
        /// <summary>
        /// When Kitty finished moving, Gets Summary.
        /// </summary>
        /// <returns>Summary of movemebt</returns>
        public string Summarize()
        {
            return _deadLocked ? PrepareDeadLockMessage() : PrepareSummaryMessage();
        }
        /// <summary>
        /// Deadlock message.
        /// </summary>
        /// <returns>Deadlock message.</returns>
        private string PrepareDeadLockMessage()
        {
            return $"You are deadlocked, you greedy kitty!{Environment.NewLine}Jumps before deadlock: {_numberOfJumps}";
        }
        /// <summary>
        /// Normal finish.
        /// </summary>
        /// <returns>Normal finish.</returns>
        private string PrepareSummaryMessage()
        {
            return $"Coder souls collected: {_coderSouls}{Environment.NewLine}Food collected: {_food}{Environment.NewLine}Deadlocks: {_deadlocks}";
        }
      
    }
