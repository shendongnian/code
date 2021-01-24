using (var dcMachines = new DataContextM())
{
    var now = DateTime.Now;
    var utcYesterday = DateTime.UtcNow.AddDays(-1);
    var devicesMachinesQuery =
        from dm in dcMachines.DevicesMachines
        where dm.From <= now && dm.To >= now
        join d in dcMachines.Devices on dm.IdDevice equals d.Id into dItems
        from d in dItems.DefaultIfEmpty()
        select new
        {
            dm.IdMachine,
            dm.IdDevice,
            DeviceCode = d.Code
        };
    var errorsQuery =
        from err in dcMachines.Errors
        where err.Moment >= utcYesterday
        select err;
    IEnumerable<MachineRow> lstM =
        from m in dcMachines.Machines
        join dm in devicesMachinesQuery on m.Id equals dm.IdMachine into dmItems
        from dm in dmItems.DefaultIfEmpty()
        select new MachineRow
        {
            Id = m.Id,
            Code = m.Code,
            DeviceCode = dm != null ? dm.DeviceCode : "NA",
            IdDevice = dm != null ? dm.IdDevice : 0,
            ErrorCnt = (
                from err in errorsQuery
                where err.IdMachine == m.Id
                select err.Id
                )
                .Count()
        };
}
I made some tests in memory and it seems to yield the same behavior as your provided SQL query.
