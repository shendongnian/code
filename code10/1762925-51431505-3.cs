    var computer = new Computer();
    computer.GPUEnabled = true;
    computer.Open();
    var gpu = computer.Hardware.First(x => x.HardwareType == HardwareType.GpuNvidia);
    var totalVideoRamInMB = gpu.Sensors.First(x => x.Name.Equals("GPU Memory Total")).Value / 1024;
    computer.Close();
