    int CountWires(EStatus? status, ESize? size, EVoltage? voltage, EPhase? phase)
    {
        int count = 0;
        foreach (Wire wire in _connectedWires)
        {
            if (status.HasValue && wire.Status.Value != status) continue;
            if (size.HasValue && wire.Size.Value != size) continue;
            ...
            ++count;
        }
        return count;
    }
