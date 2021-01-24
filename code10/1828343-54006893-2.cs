    public class Action
    {
        /// <summary>
        /// Start video
        /// </summary>
        public static readonly Action START_VIDEO = new Action("Start video");
        /// <summary>
        /// Pause video
        /// </summary>
        public static readonly Action PAUSE_VIDEO = new Action("Pause video");
        /// <summary>
        /// Rewind video
        /// </summary>
        public static readonly Action REWIND_VIDEO = new Action("Rewind video");
        private readonly string _value;
        private Action(string value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value;
        }
        public static implicit operator string(Action action)
        {
            return action._value;
        }
    }
