    public List<Category> ContainsResources(List<Category> qry)
    {
        List<Category> lstResourceIsInActivity =  qry.Where(p => p.ExternalResources.Any(c => c.IsInActivity)).ToList();
        lstResourceIsInActivity.ForEach(c => c.ExternalResources = c.ExternalResources.Where(e => e.IsInActivity).ToList());
        return lstResourceIsInActivity;
    }
