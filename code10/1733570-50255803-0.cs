    using System.Threading.Tasks;
    public bool myMainFunction()
    {
        bool result = updateTable1();
        Task.Run(() => updateTable2());
        return result;    
    }
