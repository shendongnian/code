    int CountWires(EStatus? status, ESize? size, EVoltage? voltage, EPhase? phase)
    {
        int count = 0;
        foreach (Wire wire in _connectedWires)
        {
            if (status.HasValue && wire.Status != status.Value) continue;
            if (size.HasValue && wire.Size != size.Value) continue;
            ...
            ++count;
        }
        return count;
    }
