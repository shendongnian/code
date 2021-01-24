    using System.Threading.Tasks;
    public bool MyMainFunction()
    {
        bool result = UpdateTable1();
        Task.Run(() => UpdateTable2());
        return result;    
    }
