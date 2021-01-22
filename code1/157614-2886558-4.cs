    internal class MatrixStateSpace : IStateSpace
    {
        IState GetStateAt(IPosition position)
        {
            return this.Matrix[position];
        }
        void SetStateAt(IPosition position, IState state)
        {
            this.Matrix[position] = state;
        }
    }
    internal class GraphStateSpace : IStateSpace
    {
        IState GetStateAt(IPosition position)
        {
            return this.Graph.Find(position).State;
        }
        void SetStateAt(IPosition position, IState state)
        {
            this.Graph.Find(position).State = state;
        }
    }
