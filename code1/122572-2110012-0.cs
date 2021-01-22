    public class PlayerPosition {
        public PlayerPosition (string positionName, bool isDefensive ) {
            this.Name = positionName;
            this.IsDefensive = isDefensive ;
        }
        public string Name { get; private set; }
        public bool IsDefensive { get; private set; }
    }
