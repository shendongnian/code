    public class ConnectionItem 
    {
        public ConnectionItem(string name)
        {
            Name = name;
        }
        public string Name { get; }
        private Brush _color = Brushes.Red;
        public Brush Color { get => _color; }
        private ConnectionStatus _status;
        public ConnectionStatus Status
        {
            set
            {
                if (value == _status)
                {
                    return;
                }
                else
                {
                    switch (value)
                    {
                        case ConnectionStatus.Connected:
                            _color = Brushes.Yellow;
                            break;
                        case ConnectionStatus.Ready:
                            _color = Brushes.Green;
                            break;
                        default:
                            _color = Brushes.Red;
                            break;
                   }
               }
            }
        }
    }
