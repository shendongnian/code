    using System.Threading.Tasks;
    public bool MyMainFunction()
    {
        Task<bool> task = Task.Run(() => UpdateTable1());
        Task.Run(() => UpdateTable2());
        return task.Result;
    }
