    public List<string> FilterList(string[] FilterBoxes)
        {
            List<string> R = FilterBoxes.Where(x => String.IsNullOrWhiteSpace(x) == false).ToList<string>();
            return R;
        }
    
