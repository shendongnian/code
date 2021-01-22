    public interface IBasic
    {  
        int GetData();
    }
    
    public interface IChangeable : IBasic
    {  
        void SetData(int data)
    }
