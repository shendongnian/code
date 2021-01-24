    public string GetPaths(IEnumerable<SpecialityTreeItem> stil)
    {
        int pathCounter;
        StringBuilder sb = new StringBuilder();
        foreach(var sti in stil)
        {
            if (sti.Offices.Count == 0)
                sb.Append($"{pathCounter++} {sti}\n");
            else
            {
                foreach (var oti in sti.Offices)
                {
                    if (oti.Doctors.Count == 0)
                        sb.Append($"{pathCounter++} {sti} -- {oti}\n");
                    else
                    {
                        foreach (var dti in oti.Doctors)
                        {
                            sb.Append($"{pathCounter++} {sti} -- {oti} -- {dti}\n");
                        }
                    }
                }
            }
        }
        return sb.ToString();
    }
