    var result = entities.MachineRevision
                     .Where(x => x.Machine.IdMachine == pIdMachine)
                     .Where(y => y.Category == (int)pCategory)
                     .FirstOrDefault();
    if (result != null)
    {
         return new oMachineRevision(result.IdMachineRevision);
    }
